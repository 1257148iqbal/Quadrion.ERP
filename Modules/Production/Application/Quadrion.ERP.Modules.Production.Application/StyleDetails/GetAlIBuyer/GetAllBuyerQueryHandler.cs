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

namespace Quadrion.ERP.Modules.Reports.Application.StyleDetails.GetAllBuyer
{
    internal class GetAllBuyerQueryHandler : IQueryHandler<GetAllBuyerQuery, PagedResponse<List<GetBuyerDto>>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAllBuyerQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<PagedResponse<List<GetBuyerDto>>> Handle(GetAllBuyerQuery query, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string countQuery = @"SELECT COUNT([Style].[BuyerId]) FROM [merchandising].[Styles] AS [Style] /**where**/";

            const string sqlTemplate = @"SELECT
                                            [Style].[BuyerId]
                                           ,[Style].[BuyerName]
                                            FROM [merchandising].[Styles] AS [Style]
                                            GROUP BY 
                                            [Style].[BuyerId]                                           
                                            ,[Style].[BuyerName]";

            var sqlBuilder = new SqlBuilder();
            var template = sqlBuilder.AddTemplate(sqlTemplate);
            var count = sqlBuilder.AddTemplate(countQuery);

            var pageData = PagedQueryHelper.GetPageData(query);

            var setStyles = await connection.QueryAsync<GetBuyerDto>(template.RawSql);

            var totalCount = connection.Query<int>(count.RawSql).Single();
            return PagedQueryHelper.CreatePagedResponse(setStyles.ToList(), pageData, totalCount);
        }
    }
}