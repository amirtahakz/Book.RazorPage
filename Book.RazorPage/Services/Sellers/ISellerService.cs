using Book.RazorPage.Models;
using Book.RazorPage.Models.Sellers;
using Book.RazorPage.Models.Sellers.Commands;

namespace Book.RazorPage.Services.Sellers;

public interface ISellerService
{
    Task<ApiResult> CreateSeller(CreateSellerCommand command);
    Task<ApiResult> EditSeller(EditSellerCommand command);
    Task<ApiResult> AddInventory(AddSellerInventoryCommand command);
    Task<ApiResult> EditInventory(EditSellerInventoryCommand command);

    Task<SellerDto?> GetSellerById(Guid sellerId);
    Task<SellerDto?> GetCurrentSeller();
    Task<SellerFilterResult> GetSellersByFilter(SellerFilterParams filterParams);

    Task<InventoryDto?> GetInventoryById(Guid inventoryId);
    Task<List<InventoryDto>> GetSellerInventories();
}