namespace Book.RazorPage.Models.Orders.Command;

public class AddOrderItemCommand
{
    public Guid InventoryId { get; set; }
    public Guid UserId { get; set; }
    public int Count { get; set; }
}