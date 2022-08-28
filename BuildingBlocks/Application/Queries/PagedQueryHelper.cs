using System;
using System.Collections.Generic;
using System.Text;
using Quadrion.ERP.BuildingBlocks.Application.ApiResponse;

namespace Quadrion.ERP.BuildingBlocks.Application.Queries
{
    public static class PagedQueryHelper
    {
        public const string Offset = "Offset";

        public const string Next = "Next";

        public static PageData GetPageData(IPagedQuery query)
        {
            int pageNumber;
            int pageSize;
            int offset;
            if (!query.Page.HasValue ||
                !query.PerPage.HasValue)
            {
                pageNumber = 1;
                offset = 0;
            }
            else
            {
                pageNumber = (query.Page.Value == 0 ? 1 : query.Page.Value);
                offset = (query.Page.Value == 0 ? query.Page.Value : query.Page.Value - 1) * query.PerPage.Value;
            }

            int next;
            if (!query.PerPage.HasValue)
            {
                pageSize = next = int.MaxValue;
            }
            else
            {
                pageSize = next = query.PerPage.Value;
            }

            return new PageData(offset, next, pageNumber, pageSize);
        }

        public static string AppendPageStatement(string sql)
        {
            return $"{sql} " + $"OFFSET @{Offset} ROWS FETCH NEXT @{Next} ROWS ONLY; ";
        }

        public static PagedResponse<List<T>> CreatePagedResponse<T>(List<T> pagedData, PageData validFilter, int totalRecords)
        {
            var response = new PagedResponse<List<T>>(pagedData, validFilter.PageNumber, validFilter.PageSize);

            var totalPages = ((double)totalRecords / (double)validFilter.PageSize);

            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            response.TotalPages = roundedTotalPages;
            response.TotalRecords = totalRecords;
            return response;
        }

    }
}