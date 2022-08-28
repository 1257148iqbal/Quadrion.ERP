using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Quadrion.ERP.BuildingBlocks.Infrastructure.EventBus;
using Serilog;

namespace Quadrion.ERP.Modules.Reports.Infrastructure.Configuration.EventBus
{
    public static class EventsBusStartup
    {
        public static void Initialize(
            ILogger logger)
        {
            SubscribeToIntegrationEvents(logger);
        }

        private static void SubscribeToIntegrationEvents(ILogger logger)
        {
            var eventBus = ReportsCompositionRoot.BeginLifetimeScope().Resolve<IEventsBus>();


        }

        private static void SubscribeToIntegrationEvent<T>(IEventsBus eventBus, ILogger logger)
            where T : IntegrationEvent
        {
            logger.Information("Subscribe to {@IntegrationEvent}", typeof(T).FullName);
            eventBus.Subscribe(
                new IntegrationEventGenericHandler<T>());
        }
    }
}
