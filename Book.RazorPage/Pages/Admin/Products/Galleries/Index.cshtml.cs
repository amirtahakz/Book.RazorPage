using System.ComponentModel.DataAnnotations;
using System.Text;
using Book.RazorPage.Infrastructure.RazorUtils;
using Book.RazorPage.Infrastructure.Utils.CustomValidation.IFormFile;
using Book.RazorPage.Models.Products;
using Book.RazorPage.Models.Products.Commands;
using Book.RazorPage.Services.Products;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book.RazorPage.Pages.Admin.Products.Galleries
{
    public class IndexModel : BaseRazorPage
    {
        private IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<ProductImageDto> Images { get; set; }

        [Display(Name = "عکس محصول")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [FileImage(ErrorMessage = "عکس نامعتبر است")]
        [BindProperty]
        public IFormFile ImageFIle { get; set; }

        [Display(Name = "ترتیب نمایش")]
        [BindProperty]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public int Sequence { get; set; }

        public async Task<IActionResult> OnGet(Guid productId)
        {
            var product = await _productService.GetProductById(productId);
            if (product == null)
                return RedirectToPage("Index");

            Images = product.Images;
            return Page();
        }

        public async Task<IActionResult> OnPost(Guid productId)
        {
            return await AjaxTryCatch(() =>
            {
                return _productService.AddImage(new AddProductImageCommand()
                {
                    ProductId = productId,
                    ImageFile = ImageFIle,
                    Sequence = Sequence
                });
            });
        }

        public async Task<IActionResult> OnPostDeleteItem(Guid productId, Guid id)
        {
            Sequence = 1;
            return await AjaxTryCatch(()
                => _productService.DeleteProductImage(new DeleteProductImageCommand()
                { ProductId = productId, ImageId = id }), checkModelState: false);
        }
    }
}
