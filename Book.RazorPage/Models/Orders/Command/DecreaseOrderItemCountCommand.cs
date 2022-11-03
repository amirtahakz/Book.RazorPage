namespace Book.RazorPage.Models.Orders.Command;

public class DecreaseOrderItemCountCommand
{
    public Guid UserId { get; set; }
    public Guid ItemId { get; set; }
    public int Count { get; set; }
}