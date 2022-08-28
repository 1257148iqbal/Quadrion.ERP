using System.Reflection;
using Quadrion.ERP.Modules.UserAccess.Application.Configuration.Commands;

namespace Quadrion.ERP.Modules.UserAccess.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(InternalCommandBase).Assembly;
    }
}