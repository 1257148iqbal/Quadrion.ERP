using System;
using System.Collections.Generic;
using Quadrion.ERP.BuildingBlocks.Application.ApiResponse;
using Quadrion.ERP.Modules.Reports.Application.Configuration.Queries;

namespace Quadrion.ERP.Modules.Reports.Application.StyleDetails.GetSeasonByBuyerNDepartment
{
    public class GetSeasonByBuyerNDepartmentQuery : QueryBase<Response<List<GetSeasonByBuyerNDepartmentDto>>>
    {
        public GetSeasonByBuyerNDepartmentQuery(Guid buyerId, Guid buyerDepartmentId, string year)
        {
            BuyerId = buyerId;
            BuyerDepartmentId = buyerDepartmentId;
            Year = year;
        }

        public Guid BuyerId { get; }

        public Guid BuyerDepartmentId { get; }

        public string Year { get; }
    }
}