using System;
using System.Collections.Generic;
using Quadrion.ERP.BuildingBlocks.Application.ApiResponse;
using Quadrion.ERP.Modules.Reports.Application.Configuration.Queries;

namespace Quadrion.ERP.Modules.Reports.Application.StyleDetails.GetYearByDepartment
{
    public class GetYearByDepartmentQuery : QueryBase<Response<List<GetYearByDepartmentDto>>>
    {
        public GetYearByDepartmentQuery(Guid buyerDepartmentId)
        {
            BuyerDepartmentId = buyerDepartmentId;
        }

        public Guid BuyerDepartmentId { get; }
    }
}