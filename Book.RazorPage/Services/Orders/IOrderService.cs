using Book.RazorPage.Models;
using Book.RazorPage.Models.Orders;
using Book.RazorPage.Models.Orders.Command;

namespace Book.RazorPage.Services.Orders;

public interface IOrderService
{
    Task<ApiResult> AddOrderItem(AddOrderItemCommand command);
    Task<ApiResult> CheckoutOrder(CheckOutOrderCommand command);
    Task<ApiResult> IncreaseOrderItem(IncreaseOrderItemCountCommand command);
    Task<ApiResult> DecreaseOrderItem(DecreaseOrderItemCountCommand command);
    Task<ApiResult> DeleteOrderItem(DeleteOrderItemCommand command);
    Task<ApiResult> SendOrder(Guid orderId);


    Task<OrderDto?> GetOrderById(Guid orderId);
    Task<OrderDto?> GetCurrentOrder();
    Task<OrderFilterResult> GetOrders(OrderFilterParams filterParams);
    Task<OrderFilterResult> GetUserOrders(int pageId, int take, OrderStatus? orderStatus);

}