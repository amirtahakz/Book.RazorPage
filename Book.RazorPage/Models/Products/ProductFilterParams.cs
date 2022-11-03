namespace Book.RazorPage.Models.Products;

public class ProductFilterParams : BaseFilterParam
{
    public string? Title { get; set; }
    public Guid? Id { get; set; }
    public string? Slug { get; set; }
}