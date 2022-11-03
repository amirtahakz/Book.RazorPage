using Book.RazorPage.Models;
using Book.RazorPage.Models.Banners;

namespace Book.RazorPage.Services.Banners;

public interface IBannerService
{
    Task<ApiResult> CreateBanner(CreateBannerCommand command);
    Task<ApiResult> EditBanner(EditBannerCommand command);
    Task<ApiResult> DeleteBanner(Guid bannerId);

    Task<BannerDto?> GetBannerById(Guid bannerId);
    Task<List<BannerDto>> GetList();

}