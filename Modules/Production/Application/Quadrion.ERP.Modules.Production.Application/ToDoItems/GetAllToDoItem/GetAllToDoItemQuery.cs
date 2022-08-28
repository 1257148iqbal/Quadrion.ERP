using System;
using System.Collections.Generic;
using System.Text;
using Quadrion.ERP.BuildingBlocks.Application.ApiResponse;
using Quadrion.ERP.BuildingBlocks.Application.Queries;
using Quadrion.ERP.Modules.Reports.Application.Configuration.Queries;

namespace Quadrion.ERP.Modules.Reports.Application.ToDoItems.GetAllToDoItem
{
    public class GetAllToDoItemQuery : QueryBase<PagedResponse<List<GetToDoItemDto>>>, IPagedQuery
    {
        public GetAllToDoItemQuery(int? page, int? perPage, string searchKey, bool status)
        {
            Page = page;
            PerPage = perPage;
            SearchKey = searchKey;
            Status = status;
        }

        public int? Page { get; }

        public int? PerPage { get; }

        public string SearchKey { get; }

        public bool Status { get; }
    }
}