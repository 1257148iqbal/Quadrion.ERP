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

namespace Quadrion.ERP.Modules.Reports.Application.StyleDetails.GetDepartmentByBuyer
{
    internal class GetDepartmentByBuyerQueryHandler : IQueryHandler<GetDepartmentByBuyerQuery, Response<List<GetDepartmentByBuyerDto>>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetDepartmentByBuyerQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Response<List<GetDepartmentByBuyerDto>>> Handle(GetDepartmentByBuyerQuery query, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string sqlTemplate = @"SELECT
                                            [Style].[BuyerDepartmentId]
                                           ,[Style].[BuyerDepartment]
                                            FROM [merchandising].[Styles] AS [Style]
                                            WHERE [Style].[BuyerId] = @BuyerId
                                            GROUP BY 
                                            [Style].[BuyerDepartmentId]                                           
                                            ,[Style].[BuyerDepartment]";

            var sqlBuilder = new SqlBuilder();
            var template = sqlBuilder.AddTemplate(sqlTemplate);

            sqlBuilder.OrderBy($"[BuyerDepartment] ASC");

            var joinedData = await connection.QueryAsync<GetDepartmentByBuyerDto>(template.RawSql, new { BuyerId = query.BuyerId });

            return new Response<List<GetDepartmentByBuyerDto>>(joinedData.ToList());
        }
    }
}