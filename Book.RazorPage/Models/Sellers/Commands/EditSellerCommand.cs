namespace Book.RazorPage.Models.Sellers.Commands;

public class EditSellerCommand
{
    public Guid Id { get; set; }
    public string ShopName { get; set; }
    public string NationalCode { get; set; }
    public SellerStatus Status { get; set; }
}