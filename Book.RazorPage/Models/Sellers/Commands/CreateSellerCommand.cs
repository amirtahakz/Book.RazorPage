namespace Book.RazorPage.Models.Sellers.Commands;

public class CreateSellerCommand
{
    public Guid UserId { get; set; }
    public string ShopName { get; set; }
    public string NationalCode { get; set; }
}