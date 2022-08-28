using Autofac;
using Quadrion.ERP.BuildingBlocks.EventBus;
using Quadrion.ERP.BuildingBlocks.Infrastructure.EventBus;

namespace Quadrion.ERP.Modules.UserAccess.Infrastructure.Configuration.EventsBus
{
    internal class EventsBusModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InMemoryEventBusClient>()
                .As<IEventsBus>()
                .SingleInstance();
        }
    }
}