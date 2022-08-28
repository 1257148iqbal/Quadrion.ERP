using System;
using System.Collections.Generic;

namespace Quadrion.ERP.Modules.Reports.Application.StyleDetails.GetStyleDetailsById
{
    public class GetSizeGroupsDto
    {
        public Guid SizeGroupId { get; set; }

        public string SizeGroupName { get; set; }

        public List<GetSizesDto> SizesList { get; set; }
    }
}