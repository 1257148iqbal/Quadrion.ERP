using System;
using Autofac;
using Quadrion.ERP.BuildingBlocks.Application;
using Quadrion.ERP.BuildingBlocks.Application.Emails;
using Quadrion.ERP.BuildingBlocks.Infrastructure;
using Quadrion.ERP.BuildingBlocks.Infrastructure.Emails;
using Quadrion.ERP.Modules.UserAccess.Infrastructure.Configuration.DataAccess;
using Quadrion.ERP.Modules.UserAccess.Infrastructure.Configuration.Email;
using Quadrion.ERP.Modules.UserAccess.Infrastructure.Configuration.EventsBus;
using Quadrion.ERP.Modules.UserAccess.Infrastructure.Configuration.Logging;
using Quadrion.ERP.Modules.UserAccess.Infrastructure.Configuration.Mediation;
using Quadrion.ERP.Modules.UserAccess.Infrastructure.Configuration.Processing;
using Quadrion.ERP.Modules.UserAccess.Infrastructure.Configuration.Processing.Outbox;
using Quadrion.ERP.Modules.UserAccess.Infrastructure.Configuration.Quartz;
using Quadrion.ERP.Modules.UserAccess.Infrastructure.Configuration.Security;
using Serilog;
using Serilog.AspNetCore;

namespace Quadrion.ERP.Modules.UserAccess.Infrastructure.Configuration
{
    public class UserAccessStartup
    {
        private static IContainer _container;

        public static void Initialize(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger,
            EmailsConfiguration emailsConfiguration,
            string textEncryptionKey,
            IEmailSender emailSender)
        {
            var moduleLogger = logger.ForContext("Module", "UserAccess");

            ConfigureCompositionRoot(
                connectionString,
                executionContextAccessor,
                logger,
                emailsConfiguration,
                textEncryptionKey,
                emailSender);

            QuartzStartup.Initialize(moduleLogger);

            EventsBusStartup.Initialize(moduleLogger);
        }

        private static void ConfigureCompositionRoot(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor,
            ILogger logger,
            EmailsConfiguration emailsConfiguration,
            string textEncryptionKey,
            IEmailSender emailSender)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "UserAccess")));
            var loggerFactory = new SerilogLoggerFactory(logger);
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
      
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new EventsBusModule());
            containerBuilder.RegisterModule(new MediatorModule());

            var domainNotificationsMap = new BiDictionary<string, Type>();
            containerBuilder.RegisterModule(new OutboxModule(domainNotificationsMap));

            containerBuilder.RegisterModule(new QuartzModule());
            containerBuilder.RegisterModule(new EmailModule(emailsConfiguration, emailSender));
            containerBuilder.RegisterModule(new SecurityModule(textEncryptionKey));

            containerBuilder.RegisterInstance(executionContextAccessor);

            _container = containerBuilder.Build();

            UserAccessCompositionRoot.SetContainer(_container);
        }
    }
}