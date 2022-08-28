using System;
using Autofac;
using Quadrion.ERP.BuildingBlocks.Application;
using Quadrion.ERP.BuildingBlocks.Infrastructure;
using Quadrion.ERP.BuildingBlocks.Infrastructure.Emails;
using Quadrion.ERP.BuildingBlocks.Infrastructure.EventBus;
using Quadrion.ERP.Modules.Reports.Infrastructure.Configuration.DataAccess;
using Quadrion.ERP.Modules.Reports.Infrastructure.Configuration.Email;
using Quadrion.ERP.Modules.Reports.Infrastructure.Configuration.EventBus;
using Quadrion.ERP.Modules.Reports.Infrastructure.Configuration.Logging;
using Quadrion.ERP.Modules.Reports.Infrastructure.Configuration.Mediation;
using Quadrion.ERP.Modules.Reports.Infrastructure.Configuration.Processing;
using Quadrion.ERP.Modules.Reports.Infrastructure.Configuration.Processing.Outbox;
using Quadrion.ERP.Modules.Reports.Infrastructure.Configuration.Quartz;
using Serilog.Extensions.Logging;
using ILogger = Serilog.ILogger;

namespace Quadrion.ERP.Modules.Reports.Infrastructure.Configuration
{
    public class ReportsStartup
    {
         private static IContainer _container;

        public static void Initialize(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger,
            EmailsConfiguration emailsConfiguration,
            IEventsBus eventsBus)
        {
            var moduleLogger = logger.ForContext("Module", "Reports");

            ConfigureCompositionRoot(
                connectionString,
                executionContextAccessor,
                moduleLogger,
                emailsConfiguration,
                eventsBus);

            QuartzStartup.Initialize(moduleLogger);

            EventsBusStartup.Initialize(moduleLogger);
        }

        public static void Stop()
        {
            QuartzStartup.StopQuartz();
        }

        private static void ConfigureCompositionRoot(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger,
            EmailsConfiguration emailsConfiguration,
            IEventsBus eventsBus)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "Reports")));

            var loggerFactory = new SerilogLoggerFactory(logger);
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new EventsBusModule(eventsBus));
            containerBuilder.RegisterModule(new MediatorModule());

            var domainNotificationsMap = new BiDictionary<string, Type>();

            containerBuilder.RegisterModule(new OutboxModule(domainNotificationsMap));

            containerBuilder.RegisterModule(new EmailModule(emailsConfiguration));
            containerBuilder.RegisterModule(new QuartzModule());

            containerBuilder.RegisterInstance(executionContextAccessor);

            _container = containerBuilder.Build();

            ReportsCompositionRoot.SetContainer(_container);
        }
    }
}
