using Book.RazorPage.Infrastructure.RazorUtils;
using Book.RazorPage.Models;
using Book.RazorPage.Models.Sellers;
using Book.RazorPage.Models.Sellers.Commands;
using Book.RazorPage.Services.Sellers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book.RazorPage.Pages.SellerPanel.Inventories;

public class IndexModel : BaseRazorPage
{
    private ISellerService _sellerService;
    private IRenderViewToString _renderViewToString;
    public IndexModel(ISellerService sellerService, IRenderViewToString renderViewToString)
    {
        _sellerService = sellerService;
        _renderViewToString = renderViewToString;
    }

    public List<InventoryDto> Inventories { get; set; }
    public async Task<IActionResult> OnGet()
    {
        var seller = await _sellerService.GetCurrentSeller();
        if (seller == null)
            return Redirect("/");

        Inventories = await _sellerService.GetSellerInventories();
        return Page();
    }

    public async Task<IActionResult> OnGetEditPage(Guid id)
    {
        return await AjaxTryCatch(async () =>
        {
            var inventory = await _sellerService.GetInventoryById(id);
            if (inventory == null)
                return ApiResult<string>.Success("اطلاعات نامعتبر است");
            var view = await _renderViewToString.RenderToStringAsync("_Edit", new EditSellerInventoryCommand
            {
                SellerId = inventory.SellerId,
                InventoryId = inventory.Id,
                Count = inventory.Count,
                Price = inventory.Price,
                DiscountPercentage = inventory.DiscountPercentage
            }, PageContext);
            return ApiResult<string>.Success(view);
        });
    }

    public async Task<IActionResult> OnPost(EditSellerInventoryCommand command)
    {
        return await AjaxTryCatch(() => _sellerService.EditInventory(command));
    }
}