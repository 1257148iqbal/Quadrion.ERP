using Autofac;
using Quadrion.ERP.Modules.UserAccess.Application.Contracts;
using Quadrion.ERP.Modules.UserAccess.Infrastructure;

namespace Quadrion.ERP.API.Modules.UserAccess
{
    public class UserAccessAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserAccessModule>()
                .As<IUserAccessModule>()
                .InstancePerLifetimeScope();
        }
    }
}