using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Quadrion.ERP.BuildingBlocks.Application.ApiResponse;
using Quadrion.ERP.BuildingBlocks.Application.Data;
using Quadrion.ERP.Modules.Reports.Application.Configuration.Queries;

namespace Quadrion.ERP.Modules.Reports.Application.StyleDetails.GetYearByDepartment
{
    internal class GetYearByDepartmentQueryHandler : IQueryHandler<GetYearByDepartmentQuery, Response<List<GetYearByDepartmentDto>>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetYearByDepartmentQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Response<List<GetYearByDepartmentDto>>> Handle(GetYearByDepartmentQuery query, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string sqlTemplate = @"SELECT
                                            [Style].[Year]
                                            FROM [merchandising].[Styles] AS [Style]
                                            WHERE [Style].[BuyerDepartmentId] = @BuyerDepartmentId
                                            GROUP BY                                         
                                            [Style].[Year]";

            var sqlBuilder = new SqlBuilder();
            var template = sqlBuilder.AddTemplate(sqlTemplate);

            sqlBuilder.OrderBy($"[Year] ASC");

            var joinedData = await connection.QueryAsync<GetYearByDepartmentDto>(template.RawSql, new { BuyerDepartmentId = query.BuyerDepartmentId });

            return new Response<List<GetYearByDepartmentDto>>(joinedData.ToList());
        }
    }
}