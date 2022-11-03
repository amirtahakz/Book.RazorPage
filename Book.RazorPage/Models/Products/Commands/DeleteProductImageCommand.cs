namespace Book.RazorPage.Models.Products.Commands;

public class DeleteProductImageCommand
{
    public Guid ImageId { get; set; }
    public Guid ProductId { get; set; }
}