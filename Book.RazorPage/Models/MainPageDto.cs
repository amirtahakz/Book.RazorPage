using Book.RazorPage.Models.Banners;
using Book.RazorPage.Models.Products;
using Book.RazorPage.Models.Sliders;

namespace Book.RazorPage.Models;

public class MainPageDto
{
    public List<SliderDto> Sliders { get; set; }
    public List<BannerDto> Banners { get; set; }
    public List<ProductShopDto> SpectialProducts { get; set; }
    public List<ProductShopDto> LatestProducts { get; set; }
    public List<ProductShopDto> TopVisitProducts { get; set; }

}