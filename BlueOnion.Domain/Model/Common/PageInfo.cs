namespace BlueOnion.Domain.Model
{
    /// <summary>
    /// This will hold paging information used for paging controls
    /// </summary>
    public class PageInfo
    {

        public PageInfo()
        {
            PageSize = 10;
        }
        public PageInfo(int top, int skip, long totalRecords) : this(top, skip, totalRecords, totalRecords) { }

        public PageInfo(int top, int skip, long totalRecords, long totalRecordsWithOutSearch)
        {

            if (top == 0)
            {
                top = 10;
            }

            var pageSize = top;
            var page = skip == 0 ? 1 : ((skip + top) / top);

            this.PageCount = (totalRecords + pageSize - 1) / pageSize;
            this.TotalItemCount = totalRecords;
            this.TotalItemCountWithoutSearch = totalRecordsWithOutSearch == 0 ? totalRecords : totalRecordsWithOutSearch;
            this.PageNumber = page;
            this.PageSize = pageSize;
            this.HasPreviousPage = page > 1;
            this.HasNextPage = page != this.PageCount;
            this.IsFirstPage = page == 1;
            this.IsLastPage = page == this.PageCount;
            this.FirstItemOnPage = ((page - 1) * pageSize) + 1;
            this.LastItemOnPage = this.IsLastPage ? totalRecords : (FirstItemOnPage + pageSize - 1);
            this.Search = "";
            this.PageBase = 0;
            if (page > 3 && PageCount > 5)
            {
                this.PageBase = page - 3;
            }
        }

        public long TotalItemCountWithoutSearch { get; set; }
        public long PageCount { get; set; }
        public long TotalItemCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
        public int FirstItemOnPage { get; set; }
        public long LastItemOnPage { get; set; }
        public string Search { get; set; }
        private int PageBase { get; set; }

        public string Page1
        {
            get
            {
                return (PageBase + 1).ToString();
            }
        }
        public string Page2
        {
            get
            {
                if (PageCount < 2)
                    return "";

                return (PageBase + 2).ToString();
            }
        }
        public string Page3
        {
            get
            {
                if (PageCount < 3)
                    return "";

                return (PageBase + 3).ToString();
            }
        }
        public string Page4
        {
            get
            {
                if (PageCount < 4)
                    return "";
                return (PageBase + 4).ToString();
            }
        }
        public string Page5
        {
            get
            {
                if (PageCount < 5)
                    return "";
                return (PageBase + 5).ToString();
            }
        }
    }
}
