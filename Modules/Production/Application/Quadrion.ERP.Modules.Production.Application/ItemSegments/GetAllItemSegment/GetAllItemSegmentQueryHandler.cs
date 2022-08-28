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

namespace Quadrion.ERP.Modules.Reports.Application.ItemSegments.GetAllItemSegment
{
    internal class GetAllItemSegmentQueryHandler : IQueryHandler<GetAllItemSegmentQuery, PagedResponse<List<GetItemSegmentDto>>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAllItemSegmentQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<PagedResponse<List<GetItemSegmentDto>>> Handle(GetAllItemSegmentQuery query, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string countQuery = @"SELECT COUNT([ItemSegment].[Id]) FROM [inventory].[ItemSegment] AS [ItemSegment] /**where**/";

            const string sqlTemplate = @";
                                        WITH _data
                                        AS
                                        (SELECT
                                            [ItemSegment].[Id]
                                           ,[ItemSegment].[Name]
                                           ,[ItemSegment].[Description]
                                          FROM [inventory].[ItemSegment] AS [ItemSegment]
                                         /**where**/)

                                        SELECT
                                          *
                                        FROM _data
                                        /**orderby**/";

            var sqlBuilder = new SqlBuilder();
            var template = sqlBuilder.AddTemplate(sqlTemplate);
            var count = sqlBuilder.AddTemplate(countQuery);

            var pageData = PagedQueryHelper.GetPageData(query);

            var setStyles = await connection.QueryAsync<GetItemSegmentDto>(template.RawSql);

            var totalCount = connection.Query<int>(count.RawSql).Single();
            return PagedQueryHelper.CreatePagedResponse(setStyles.ToList(), pageData, totalCount);
        }
    }
}