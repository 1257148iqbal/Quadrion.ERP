using Autofac;
using Quadrion.ERP.Modules.Reports.Application.Contracts;
using Quadrion.ERP.Modules.Reports.Infrastructure;

namespace Quadrion.ERP.API.Modules.Reports
{
    public class ReportsAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ReportsModule>()
                .As<IReportsModule>()
                .InstancePerLifetimeScope();
        }
    }
}
