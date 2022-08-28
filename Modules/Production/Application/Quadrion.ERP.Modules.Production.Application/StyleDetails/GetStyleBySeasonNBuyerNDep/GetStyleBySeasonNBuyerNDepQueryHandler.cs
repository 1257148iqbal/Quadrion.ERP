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

namespace Quadrion.ERP.Modules.Reports.Application.StyleDetails.GetStyleBySeasonNBuyerNDep
{
    internal class GetStyleBySeasonNBuyerNDepQueryHandler : IQueryHandler<GetStyleBySeasonNBuyerNDepQuery, Response<List<GetStyleBySeasonNBuyerNDepDto>>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetStyleBySeasonNBuyerNDepQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Response<List<GetStyleBySeasonNBuyerNDepDto>>> Handle(GetStyleBySeasonNBuyerNDepQuery query, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string sqlTemplate = @"SELECT
                                            [Style].[Id]
                                            ,[Style].[StyleNo]
                                            FROM [merchandising].[Styles] AS [Style]
                                            WHERE [Style].[BuyerId] = @BuyerId AND [Style].[BuyerDepartmentId] = @BuyerDepartmentId AND [Style].[Year] = @Year AND [Style].[Season] = @Season
                                            GROUP BY
                                            [Style].[Id]
                                            ,[Style].[StyleNo]";

            var sqlBuilder = new SqlBuilder();
            var template = sqlBuilder.AddTemplate(sqlTemplate);

            sqlBuilder.OrderBy($"[StyleNo] ASC");

            var joinedData = await connection.QueryAsync<GetStyleBySeasonNBuyerNDepDto>(template.RawSql, new { BuyerId = query.BuyerId, BuyerDepartmentId = query.BuyerDepartmentId, Year = query.Year, Season = query.Season });

            return new Response<List<GetStyleBySeasonNBuyerNDepDto>>(joinedData.ToList());
        }
    }
}