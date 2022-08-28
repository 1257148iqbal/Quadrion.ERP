using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Quadrion.ERP.Modules.Reports.Application.Configuration.Commands;

namespace Quadrion.ERP.Modules.Reports.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(InternalCommandBase).Assembly;
    }
}
