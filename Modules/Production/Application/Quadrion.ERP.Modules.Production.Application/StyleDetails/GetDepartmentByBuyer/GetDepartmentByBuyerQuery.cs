using System;
using System.Collections.Generic;
using Quadrion.ERP.BuildingBlocks.Application.ApiResponse;
using Quadrion.ERP.Modules.Reports.Application.Configuration.Queries;

namespace Quadrion.ERP.Modules.Reports.Application.StyleDetails.GetDepartmentByBuyer
{
    public class GetDepartmentByBuyerQuery : QueryBase<Response<List<GetDepartmentByBuyerDto>>>
    {
        public GetDepartmentByBuyerQuery(Guid buyerId)
        {
            BuyerId = buyerId;
        }

        public Guid BuyerId { get; }
    }
}