namespace SkateShop.Domain.Common
{
    public class Paged<T>
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();

        public int Page { get; set; }

        public int Size { get; set; }

        public int Total { get; set; }

        public bool HasNextPage => Page * Size < Total;

        public bool HasPreviousPage => Page > 1;
    }
}
