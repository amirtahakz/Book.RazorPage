using Book.RazorPage.Models.Products;
using Book.RazorPage.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book.RazorPage.Pages
{
    public class SearchModel : PageModel
    {
        private IProductService _productService;

        public SearchModel(IProductService productService)
        {
            _productService = productService;
        }

        public ProductShopResult FilterResult { get; set; }
        public async Task OnGet(int pageId = 1, string q = "", string category = "", bool? haveDiscount = null, bool justAvailableProducts = true)
        {
            FilterResult = await _productService.GetProductForShop(new ProductShopFilterParam()
            {
                Take = 18,
                OnlyAvailableProducts = justAvailableProducts,
                JustHasDiscount = haveDiscount,
                PageId = pageId,
                Search = q,
                CategorySlug = category,
                SearchOrderBy = ProductSearchOrderBy.Latest
            });

        }
    }
}
