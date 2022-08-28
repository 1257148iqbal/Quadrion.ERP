using System;
using System.Collections.Generic;
using Quadrion.ERP.BuildingBlocks.Application.ApiResponse;
using Quadrion.ERP.Modules.Reports.Application.Configuration.Queries;

namespace Quadrion.ERP.Modules.Reports.Application.StyleDetails.GetStyleBySeasonNBuyerNDep
{
    public class GetStyleBySeasonNBuyerNDepQuery : QueryBase<Response<List<GetStyleBySeasonNBuyerNDepDto>>>
    {
        public GetStyleBySeasonNBuyerNDepQuery(Guid buyerId, Guid buyerDepartmentId, string year, string season)
        {
            BuyerId = buyerId;
            BuyerDepartmentId = buyerDepartmentId;
            Year = year;
            Season = season;
        }

        public Guid BuyerId { get; }

        public Guid BuyerDepartmentId { get; }

        public string Year { get; }

        public string Season { get; }
    }
}