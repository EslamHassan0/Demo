public class PaginatedList<T>
{
    public List<T> Items { get; private set; }
    public int TotalItems { get; private set; }
    public int CurrentPage { get; private set; }
    public int PageSize { get; private set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);

    public PaginatedList(List<T> items, int totalItems, int currentPage, int pageSize)
    {
        Items = items;
        TotalItems = totalItems;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }
}
