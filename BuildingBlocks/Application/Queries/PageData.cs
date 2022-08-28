namespace Quadrion.ERP.BuildingBlocks.Application.Queries
{
    public struct PageData
    {
        public int? Offset { get; }

        public int? Next { get; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public PageData(int? offset, int? next, int pageNumber, int pageSize)
        {
            this.Offset = offset;
            this.Next = next;
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }
    }
}