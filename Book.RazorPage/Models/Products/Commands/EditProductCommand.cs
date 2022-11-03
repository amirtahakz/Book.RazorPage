

namespace Book.RazorPage.Models.Products.Commands;

public class EditProductCommand
{
    public Guid ProductId { get; set; }
    public string Title { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public Guid SubCategoryId { get; set; }
    public Guid? SecondarySubCategoryId { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public Dictionary<string, string> Specifications { get; set; }
}