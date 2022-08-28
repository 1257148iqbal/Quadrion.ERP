using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace Quadrion.ERP.Modules.Reports.Infrastructure.Configuration
{
   internal static class ReportsCompositionRoot
    {
        private static IContainer _container;

        internal static void SetContainer(IContainer container)
        {
            _container = container;
        }

        internal static ILifetimeScope BeginLifetimeScope()
        {
            return _container.BeginLifetimeScope();
        }
    }
}
