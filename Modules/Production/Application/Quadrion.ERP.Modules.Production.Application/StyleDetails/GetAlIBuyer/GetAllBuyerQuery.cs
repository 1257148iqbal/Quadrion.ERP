using System;
using System.Collections.Generic;
using System.Text;
using Quadrion.ERP.BuildingBlocks.Application.ApiResponse;
using Quadrion.ERP.BuildingBlocks.Application.Queries;
using Quadrion.ERP.Modules.Reports.Application.Configuration.Queries;

namespace Quadrion.ERP.Modules.Reports.Application.StyleDetails.GetAllBuyer
{
    public class GetAllBuyerQuery : QueryBase<PagedResponse<List<GetBuyerDto>>>, IPagedQuery
    {
        public GetAllBuyerQuery(int? page, int? perPage)
        {
            Page = page;
            PerPage = perPage;
        }

        public int? Page { get; }

        public int? PerPage { get; }
    }
}