using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Quartz;

namespace Quadrion.ERP.Modules.Reports.Infrastructure.Configuration.Quartz
{
    public class QuartzModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(x => typeof(IJob).IsAssignableFrom(x)).InstancePerDependency();
        }
    }
}
