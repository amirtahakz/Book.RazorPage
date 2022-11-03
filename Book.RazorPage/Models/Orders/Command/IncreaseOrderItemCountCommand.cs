namespace Book.RazorPage.Models.Orders.Command;

public class IncreaseOrderItemCountCommand
{
    public Guid UserId { get; set; }
    public Guid ItemId { get; set; }
    public int Count { get; set; }
}