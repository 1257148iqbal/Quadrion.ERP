using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Quadrion.ERP.BuildingBlocks.Application.ApiResponse;
using Quadrion.ERP.BuildingBlocks.Application.Data;
using Quadrion.ERP.BuildingBlocks.Application.Queries;
using Quadrion.ERP.Modules.Reports.Application.Configuration.Queries;

namespace Quadrion.ERP.Modules.Reports.Application.ToDoItems.GetAllToDoItem
{
    internal class GetAllToDoItemQueryHandler : IQueryHandler<GetAllToDoItemQuery, PagedResponse<List<GetToDoItemDto>>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAllToDoItemQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<PagedResponse<List<GetToDoItemDto>>> Handle(GetAllToDoItemQuery query, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            var parameters = new DynamicParameters();

            const string countQuery = @"SELECT COUNT([ToDoItem].[Id]) FROM [Reports].[ToDoItems] AS [ToDoItem] /**where**/";

            const string sqlTemplate = @";
                                        WITH _data
                                        AS
                                        (SELECT
                                            [ToDoItem].[Id]
                                           ,[ToDoItem].[Title]
                                          FROM [Reports].[ToDoItems] AS [ToDoItem]
                                         /**where**/)

                                        SELECT
                                          *
                                        FROM _data
                                        /**orderby**/";

            var sqlBuilder = new SqlBuilder();
            var template = sqlBuilder.AddTemplate(sqlTemplate);
            var count = sqlBuilder.AddTemplate(countQuery);

            var pageData = PagedQueryHelper.GetPageData(query);
            parameters.Add(nameof(PagedQueryHelper.Offset), pageData.Offset);
            parameters.Add(nameof(PagedQueryHelper.Next), pageData.Next);

            var setStyles = await connection.QueryAsync<GetToDoItemDto>(template.RawSql, parameters);

            var totalCount = connection.Query<int>(count.RawSql, parameters).Single();
            return PagedQueryHelper.CreatePagedResponse(setStyles.ToList(), pageData, totalCount);
        }
    }
}