namespace Book.RazorPage.Models.Products.Commands;

public class AddProductImageCommand
{
    public IFormFile ImageFile { get; set; }
    public Guid ProductId { get; set; }
    public int Sequence { get; set; }
}