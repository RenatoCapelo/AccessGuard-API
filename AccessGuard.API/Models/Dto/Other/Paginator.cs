namespace AccessGuard_API.Models.Dto.Other
{
    public class Paginator<T>
    {
        public int PageIndex { get; set; }
        public int TotalCount { get; set; } = 0;
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public IEnumerable<T> Results { get; set; } = Enumerable.Empty<T>();

    }
}
