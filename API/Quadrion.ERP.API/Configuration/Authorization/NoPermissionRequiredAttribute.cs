using System;

namespace Quadrion.ERP.API.Configuration.Authorization
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class NoPermissionRequiredAttribute : Attribute
    {
    }
}