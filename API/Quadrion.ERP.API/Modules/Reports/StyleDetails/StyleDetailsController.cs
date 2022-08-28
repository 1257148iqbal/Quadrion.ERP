using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quadrion.ERP.API.Configuration.Authorization;
using Quadrion.ERP.BuildingBlocks.Application.ApiResponse;
using Quadrion.ERP.Modules.Reports.Application.Contracts;
using Quadrion.ERP.Modules.Reports.Application.StyleDetails.GetAllBuyer;
using Quadrion.ERP.Modules.Reports.Application.StyleDetails.GetDepartmentByBuyer;
using Quadrion.ERP.Modules.Reports.Application.StyleDetails.GetSeasonByBuyerNDepartment;
using Quadrion.ERP.Modules.Reports.Application.StyleDetails.GetStyleBySeasonNBuyerNDep;
using Quadrion.ERP.Modules.Reports.Application.StyleDetails.GetStyleDetailsById;
using Quadrion.ERP.Modules.Reports.Application.StyleDetails.GetYearByDepartment;

namespace Quadrion.ERP.API.Modules.Reports.StyleDetails
{
    [Route("api/reports/StyleDetails")]
    [ApiController]
    public class StyleDetailsController : ControllerBase
    {
        private readonly IReportsModule _reportsModule;

        public StyleDetailsController(IReportsModule reportsModule)
        {
            _reportsModule = reportsModule;
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpGet("GetAllBuyer")]
        [ProducesResponseType(typeof(PagedResponse<List<GetBuyerDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllBuyer(int? page, int? perPage)
        {
            var response = await _reportsModule.ExecuteQueryAsync(new GetAllBuyerQuery(page, perPage));

            return Ok(response);
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpGet("GetDepartment/Buyer/{buyerId}")]
        [ProducesResponseType(typeof(Response<List<GetDepartmentByBuyerDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDepartmentByBuyer(Guid buyerId)
        {
            var response = await _reportsModule.ExecuteQueryAsync(new GetDepartmentByBuyerQuery(buyerId));

            return Ok(response);
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpGet("GetYear/Department/{buyerDepartmentId}")]
        [ProducesResponseType(typeof(Response<List<GetYearByDepartmentDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetYearByDepartment(Guid buyerDepartmentId)
        {
            var response = await _reportsModule.ExecuteQueryAsync(new GetYearByDepartmentQuery(buyerDepartmentId));

            return Ok(response);
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpGet("GetSeason/Buyer/{buyerId}/Department/{buyerDepartmentId}/Year/{year}")]
        [ProducesResponseType(typeof(Response<List<GetSeasonByBuyerNDepartmentDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSeasonByBuyerNDepartment(Guid buyerId, Guid buyerDepartmentId, string year)
        {
            var response = await _reportsModule.ExecuteQueryAsync(new GetSeasonByBuyerNDepartmentQuery(buyerId, buyerDepartmentId, year));

            return Ok(response);
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpGet("GetStyle/Buyer/{buyerId}/Department/{buyerDepartmentId}/Year/{year}/Season/{season}")]
        [ProducesResponseType(typeof(Response<List<GetStyleBySeasonNBuyerNDepDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetStyleBySeasonNBuyerNDepartment(Guid buyerId, Guid buyerDepartmentId, string year, string season)
        {
            var response = await _reportsModule.ExecuteQueryAsync(new GetStyleBySeasonNBuyerNDepQuery(buyerId, buyerDepartmentId, year, season));

            return Ok(response);
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpGet("GetStyleDetails/Style/{styleId}")]
        [ProducesResponseType(typeof(Response<GetStyleDetailsByIdDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetStyleDetailsById(Guid styleId)
        {
            var response = await _reportsModule.ExecuteQueryAsync(new GetStyleDetailsByIdQuery(styleId));

            return Ok(response);
        }
    }
}