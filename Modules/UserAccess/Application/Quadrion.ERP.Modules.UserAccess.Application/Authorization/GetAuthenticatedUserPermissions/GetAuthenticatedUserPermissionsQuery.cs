using System.Collections.Generic;
using Quadrion.ERP.Modules.UserAccess.Application.Authorization.GetUserPermissions;
using Quadrion.ERP.Modules.UserAccess.Application.Contracts;

namespace Quadrion.ERP.Modules.UserAccess.Application.Authorization.GetAuthenticatedUserPermissions
{
    public class GetAuthenticatedUserPermissionsQuery : QueryBase<List<UserPermissionDto>>
    {
    }
}