using System;
using System.Collections.Generic;
using Quadrion.ERP.BuildingBlocks.Application.ApiResponse;
using Quadrion.ERP.Modules.Reports.Application.Configuration.Queries;

namespace Quadrion.ERP.Modules.Reports.Application.StyleDetails.GetStyleDetailsById
{
    public class GetStyleDetailsByIdQuery : QueryBase<Response<GetStyleDetailsByIdDto>>
    {
        public GetStyleDetailsByIdQuery(Guid styleId)
        {
            StyleId = styleId;
        }

        public Guid StyleId { get; }
    }
}