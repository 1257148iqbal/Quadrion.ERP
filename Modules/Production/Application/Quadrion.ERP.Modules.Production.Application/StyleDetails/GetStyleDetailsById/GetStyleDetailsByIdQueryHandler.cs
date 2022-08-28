using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Quadrion.ERP.BuildingBlocks.Application.ApiResponse;
using Quadrion.ERP.BuildingBlocks.Application.Data;
using Quadrion.ERP.Modules.Reports.Application.Configuration.Queries;

namespace Quadrion.ERP.Modules.Reports.Application.StyleDetails.GetStyleDetailsById
{
    internal class GetStyleDetailsByIdQueryHandler : IQueryHandler<GetStyleDetailsByIdQuery, Response<GetStyleDetailsByIdDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetStyleDetailsByIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Response<GetStyleDetailsByIdDto>> Handle(GetStyleDetailsByIdQuery query, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            GetStyleDetailsByIdDto data = new GetStyleDetailsByIdDto();

            const string sqlTemplate = @"SELECT
                                            [Style].[Id]
                                            ,[Style].[StyleNo]
                                            ,[Style].[SystemIdNumber]
                                            ,[Style].[Season]
                                            ,[Style].[Year]
                                            ,[Style].[BuyerId]
                                            ,[Style].[BuyerName]
                                            ,[Style].[BuyerAgentId]
                                            ,[Style].[AgentName]
                                            ,[Style].[BuyerDepartmentId]
                                            ,[Style].[BuyerDepartment]
                                            ,[Style].[StyleDivisionId]
                                            ,[Style].[StyleDivision]
                                            ,[Style].[StyleDepartmentId]
                                            ,[Style].[StyleDepartment]
                                            ,[Style].[ProductCategoryId]
                                            ,[Style].[ProductCategory]
                                            ,[Style].[StyleCategoryId]
                                            ,[Style].[StyleCategory]
                                            ,[Style].[Status]
                                            ,[Style].[Description]
                                            ,[Style].[DefaultFabDescription]
                                            ,[Style].[Remarks]
                                            ,[GarmentSizeGroup].[Id] AS SizeGroupId
                                            ,[GarmentSizeGroup].[GroupName] AS SizeGroupName
                                            ,[GarmentSize].[Id] AS SizeId
                                            ,[GarmentSize].[Name] AS SizeName
                                            ,[GarmentColor].[Id] AS ColorId
                                            ,[GarmentColor].[Name] AS ColorName
                                            FROM [merchandising].[Styles] AS [Style]
                                            INNER JOIN merchandising.StyleColors AS StyleColor ON Style.Id = StyleColor.StyleId
                                            INNER JOIN merchandising.GarmentColors AS GarmentColor ON StyleColor.ColorId = GarmentColor.Id
                                            INNER JOIN merchandising.StyleSizeGroups AS StyleSizeGroup ON Style.Id = StyleSizeGroup.StyleId
                                            INNER JOIN merchandising.GarmentSizeGroups AS GarmentSizeGroup ON StyleSizeGroup.SizeGroupId = GarmentSizeGroup.Id
                                            INNER JOIN merchandising.GarmentSizeGroupGarmentSizes AS GarmentSizeGroupGarmentSize ON GarmentSizeGroup.Id = GarmentSizeGroupGarmentSize.SizeGroupId
                                            INNER JOIN merchandising.GarmentSizes AS GarmentSize ON GarmentSizeGroupGarmentSize.SizeId = GarmentSize.Id
                                            WHERE [Style].[Id] = @StyleId";

            var sqlBuilder = new SqlBuilder();
            var template = sqlBuilder.AddTemplate(sqlTemplate);

            var joinedData = connection.Query<GetStyleDetailsWithListDto>(template.RawSql, new { StyleId = query.StyleId });

            if (joinedData.Any())
            {
                var groupInfo = joinedData.FirstOrDefault();
                data.Id = groupInfo.Id;
                data.StyleNo = groupInfo.StyleNo;
                data.SystemIdNumber = groupInfo.SystemIdNumber;
                data.Season = groupInfo.Season;
                data.Year = groupInfo.Year;
                data.BuyerId = groupInfo.BuyerId;
                data.BuyerName = groupInfo.BuyerName;
                data.BuyerAgentId = groupInfo.BuyerAgentId;
                data.AgentName = groupInfo.AgentName;
                data.BuyerDepartmentId = groupInfo.BuyerDepartmentId;
                data.BuyerDepartment = groupInfo.BuyerDepartment;
                data.StyleDivisionId = groupInfo.StyleDivisionId;
                data.StyleDivision = groupInfo.StyleDivision;
                data.StyleDepartmentId = groupInfo.StyleDepartmentId;
                data.StyleDepartment = groupInfo.StyleDepartment;
                data.ProductCategoryId = groupInfo.ProductCategoryId;
                data.ProductCategory = groupInfo.ProductCategory;
                data.StyleCategoryId = groupInfo.StyleCategoryId;
                data.StyleCategory = groupInfo.StyleCategory;
                data.Status = groupInfo.Status;
                data.Description = groupInfo.Description;
                data.DefaultFabDescription = groupInfo.DefaultFabDescription;
                data.Remarks = groupInfo.Remarks;
                data.SizeGroupsList = new List<GetSizeGroupsDto>();
                data.ColorList = new List<GetColorsDto>();

                foreach (var item in joinedData.Select(x => new { x.SizeGroupId, x.SizeGroupName }).Distinct())
                {
                    GetSizeGroupsDto subList = new GetSizeGroupsDto()
                    {
                        SizeGroupId = item.SizeGroupId,
                        SizeGroupName = item.SizeGroupName,
                        SizesList = new List<GetSizesDto>()
                    };

                    foreach (var sList in joinedData.Where(x => x.SizeGroupId == item.SizeGroupId))
                    {
                        GetSizesDto sizesList = new GetSizesDto()
                        {
                            SizeId = sList.SizeId,
                            SizeName = sList.SizeName
                        };
                        subList.SizesList.Add(sizesList);
                    }

                    data.SizeGroupsList.Add(subList);
                }

                foreach (var cl in joinedData)
                {
                    GetColorsDto colorList = new GetColorsDto()
                    {
                        ColorId = cl.ColorId,
                        ColorName = cl.ColorName
                    };

                    data.ColorList.Add(colorList);
                }
            }

            return new Response<GetStyleDetailsByIdDto>(data);
        }
    }
}