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

namespace Quadrion.ERP.Modules.Reports.Application.StyleDetails.GetSeasonByBuyerNDepartment
{
    internal class GetSeasonByBuyerNDepartmentQueryHandler : IQueryHandler<GetSeasonByBuyerNDepartmentQuery, Response<List<GetSeasonByBuyerNDepartmentDto>>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetSeasonByBuyerNDepartmentQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Response<List<GetSeasonByBuyerNDepartmentDto>>> Handle(GetSeasonByBuyerNDepartmentQuery query, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string sqlTemplate = @"SELECT
                                            [Style].[Season]
                                            FROM [merchandising].[Styles] AS [Style]
                                            WHERE [Style].[BuyerId] = @BuyerId AND [Style].[BuyerDepartmentId] = @BuyerDepartmentId AND [Style].[Year] = @Year
                                            GROUP BY 
                                            [Style].[Season]";

            var sqlBuilder = new SqlBuilder();
            var template = sqlBuilder.AddTemplate(sqlTemplate);

            sqlBuilder.OrderBy($"[Season] ASC");

            var joinedData = await connection.QueryAsync<GetSeasonByBuyerNDepartmentDto>(template.RawSql, new { BuyerId = query.BuyerId, BuyerDepartmentId = query.BuyerDepartmentId, Year = query.Year });

            return new Response<List<GetSeasonByBuyerNDepartmentDto>>(joinedData.ToList());
        }
    }
}