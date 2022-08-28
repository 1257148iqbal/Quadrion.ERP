using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quadrion.ERP.API.Configuration.Authorization;
using Quadrion.ERP.BuildingBlocks.Application.ApiResponse;
using Quadrion.ERP.Modules.Reports.Application.Contracts;
using Quadrion.ERP.Modules.Reports.Application.ItemSegments.GetAllItemSegment;

namespace Quadrion.ERP.API.Modules.Reports.ItemSegments
{
    [Route("api/reports/ItemSegments")]
    [ApiController]
    public class ItemSegmentsController : ControllerBase
    {
        private readonly IReportsModule _reportsModule;

        public ItemSegmentsController(IReportsModule reportsModule)
        {
            _reportsModule = reportsModule;
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(PagedResponse<List<GetItemSegmentDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(int? page, int? perPage)
        {
            var response = await _reportsModule.ExecuteQueryAsync(new GetAllItemSegmentQuery(page, perPage));

            return Ok(response);
        }
    }
}