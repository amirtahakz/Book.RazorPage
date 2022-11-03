using Book.RazorPage.Infrastructure;
using Book.RazorPage.Infrastructure.CookieUtils;
using Book.RazorPage.Infrastructure.RazorUtils;
using Book.RazorPage.Models;
using Book.RazorPage.Models.Orders;
using Book.RazorPage.Models.Orders.Command;
using Book.RazorPage.Services.Orders;
using Microsoft.AspNetCore.Mvc;

namespace Book.RazorPage.Pages
{
    public class ShopCartModel : BaseRazorPage
    {
        private readonly IOrderService _orderService;
        private readonly ShopCartCookieManager _shopCartCookieManager;
        public ShopCartModel(IOrderService orderService, ShopCartCookieManager shopCartCookieManager)
        {
            _orderService = orderService;
            _shopCartCookieManager = shopCartCookieManager;
        }

        public OrderDto? OrderDto { get; set; }
        public async Task OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                OrderDto = await _orderService.GetCurrentOrder();
            }
            else
            {
                
                OrderDto = _shopCartCookieManager.GetShopCart();
            }
        }

        public async Task<IActionResult> OnPostDeleteItem(Guid id)
        {
            if (User.Identity.IsAuthenticated)
            {
                return await AjaxTryCatch(() => _orderService.DeleteOrderItem(new DeleteOrderItemCommand()
                {
                    OrderItemId = id
                }));
            }
            else
            {
                return await AjaxTryCatch(async () =>
                {
                    _shopCartCookieManager.DeleteOrderItem(id);
                    return ApiResult.Success();
                });
            }


        }

        public async Task<IActionResult> OnPostIncreaseItemCount(Guid id)
        {
            if (User.Identity.IsAuthenticated)
            {
                return await AjaxTryCatch(() => _orderService.IncreaseOrderItem(new IncreaseOrderItemCountCommand()
                {
                    Count = 1,
                    UserId = User.GetUserId(),
                    ItemId = id

                }));
            }
            else
            {
                return await AjaxTryCatch(async () =>
                {
                    _shopCartCookieManager.Increase(id);
                    return ApiResult.Success();
                });
            }
        }
        public async Task<IActionResult> OnPostDecreaseItemCount(Guid id)
        {
            if (User.Identity.IsAuthenticated)
            {
                return await AjaxTryCatch(() => _orderService.DecreaseOrderItem(new DecreaseOrderItemCountCommand()
                {
                    Count = 1,
                    UserId = User.GetUserId(),
                    ItemId = id
                }));
            }
            else
            {
                return await AjaxTryCatch(async () =>
                {
                    _shopCartCookieManager.Decrease(id);
                    return ApiResult.Success();
                });
            }
        }
        public async Task<IActionResult> OnPostAddItem(Guid inventoryId, int count)
        {
            if (User.Identity.IsAuthenticated)
            {
                return await AjaxTryCatch(() => _orderService.AddOrderItem(new AddOrderItemCommand()
                {
                    UserId = User.GetUserId(),
                    InventoryId = inventoryId,
                    Count = count
                }));
            }
            else
            {
                return await AjaxTryCatch(() => _shopCartCookieManager.AddItem(inventoryId, count));
            }
        }

        public async Task<IActionResult> OnGetShopCartDetail()
        {
            OrderDto? order = new();
            if (User.Identity.IsAuthenticated)
            {
                order = await _orderService.GetCurrentOrder();
            }
            else
            {
                order = _shopCartCookieManager.GetShopCart();
            }

            return new ObjectResult(new
            {
                items = order?.Items,
                count = order?.Items.Sum(s => s.Count),
                price = $"{order?.Items.Sum(s => s.TotalPrice):#,0} تومان"
            });
        }
    }
}
