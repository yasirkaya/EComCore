namespace EComCore.Domain.Shared.RequestFeatures;
public abstract class RequestParameters
{
    const int maxPageSize = 50;
    public int PageNumber { get; set; } = 1;

    private int _pageSize = 12;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
    }
}