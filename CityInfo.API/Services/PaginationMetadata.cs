namespace CityInfo.API.Services
{
    public class PaginationMetadata
    {

        public int TotalItemCount { get; set; }

        public int TotalPageCount { get; set; }

        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public PaginationMetadata(int totalItemCount, int PageSize, int CurrentPage)
        {
            TotalItemCount = (int) Math.Ceiling(totalItemCount / (double)PageSize);
            TotalPageCount = PageSize;
            CurrentPage = CurrentPage;
            PageSize = PageSize;
        }

    }
}
