using System;
using System.Collections.Generic;

namespace Quadrion.ERP.Modules.Reports.Application.StyleDetails.GetStyleDetailsById
{
    public class GetStyleDetailsWithListDto
    {
        public Guid Id { get; set; }

        public string StyleNo { get; set; }

        public string SystemIdNumber { get; set; }

        public string Season { get; set; }

        public string Year { get; set; }

        public Guid BuyerId { get; set; }

        public string BuyerName { get; set; }

        public Guid BuyerAgentId { get; set; }

        public string AgentName { get; set; }

        public Guid BuyerDepartmentId { get; set; }

        public string BuyerDepartment { get; set; }

        public Guid StyleDivisionId { get; set; }

        public string StyleDivision { get; set; }

        public Guid StyleDepartmentId { get; set; }

        public string StyleDepartment { get; set; }

        public Guid ProductCategoryId { get; set; }

        public string ProductCategory { get; set; }

        public Guid StyleCategoryId { get; set; }

        public string StyleCategory { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public string DefaultFabDescription { get; set; }

        public string Remarks { get; set; }

        public Guid SizeGroupId { get; set; }

        public string SizeGroupName { get; set; }

        public Guid SizeId { get; set; }

        public string SizeName { get; set; }

        public Guid ColorId { get; set; }

        public string ColorName { get; set; }
    }
}