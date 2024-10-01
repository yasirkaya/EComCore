namespace EComCore.Domain.Shared.RequestFeatures;

public class ProductParameters : RequestParameters
{
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public decimal? MinRating { get; set; }
    public int? GroupId { get; set; }
    public DateTime? CreatedFrom { get; set; }
    public DateTime? CreatedTo { get; set; }
    public bool? IncludeDeleted { get; set; }
}