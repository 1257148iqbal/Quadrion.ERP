using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Quadrion.ERP.BuildingBlocks.EventBus;
using Quadrion.ERP.BuildingBlocks.Infrastructure.EventBus;

namespace Quadrion.ERP.Modules.Reports.Infrastructure.Configuration.EventBus
{
    internal class EventsBusModule : Autofac.Module
    {
        private readonly IEventsBus _eventsBus;

        public EventsBusModule(IEventsBus eventsBus)
        {
            _eventsBus = eventsBus;
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (_eventsBus != null)
            {
                builder.RegisterInstance(_eventsBus).SingleInstance();
            }
            else
            {
                builder.RegisterType<InMemoryEventBusClient>()
                    .As<IEventsBus>()
                    .SingleInstance();
            }
        }
    }
}
