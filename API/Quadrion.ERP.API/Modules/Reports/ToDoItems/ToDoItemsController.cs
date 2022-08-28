using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quadrion.ERP.API.Configuration.Authorization;
using Quadrion.ERP.BuildingBlocks.Application.ApiResponse;
using Quadrion.ERP.Modules.Reports.Application.Contracts;
using Quadrion.ERP.Modules.Reports.Application.ToDoItems.AddNewToDoItem;
using Quadrion.ERP.Modules.Reports.Application.ToDoItems.EditToDoItem;
using Quadrion.ERP.Modules.Reports.Application.ToDoItems.GetAllToDoItem;

namespace Quadrion.ERP.API.Modules.Reports.ToDoItems
{
    [Route("api/reports/ToDoItems")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly IReportsModule _reportsModule;

        public ToDoItemsController(IReportsModule reportsModule)
        {
            _reportsModule = reportsModule;
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpGet("")]
        [ProducesResponseType(typeof(PagedResponse<List<GetToDoItemDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(int? page, int? perPage, string searchKey, bool status)
        {
            var response = await _reportsModule.ExecuteQueryAsync(new GetAllToDoItemQuery(page, perPage, searchKey, status));

            return Ok(response);
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody] CreateNewToDoItemRequest request)
        {
            await _reportsModule.ExecuteCommandAsync(new AddNewToDoItemCommand(request.Title, request.List));
            return Ok();
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpPut("id")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] CreateNewToDoItemRequest request)
        {
            await _reportsModule.ExecuteCommandAsync(new EditToDoItemCommand(id, request.Title, request.List));
            return Ok();
        }
    }
}