namespace Book.RazorPage.Models.Products;

public class ProductImageDto : BaseDto
{
    public Guid ProductId { get; set; }
    public string ImageName { get; set; }
    public int Sequence { get; set; }
}