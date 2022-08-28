using System;
using System.Collections.Generic;
using System.Text;
using Quadrion.ERP.BuildingBlocks.Application.Enums;

namespace Quadrion.ERP.BuildingBlocks.Application.ApiResponse
{
    public class FilterOption
    {
        public string Field { get; set; }

        public string Value { get; set; }

        public FilterOperator Operator { get; set; }
    }
}
