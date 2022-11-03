using Book.RazorPage.Infrastructure;
using Book.RazorPage.Infrastructure.RazorUtils;
using Book.RazorPage.Models.Comments;
using Book.RazorPage.Models.Products;
using Book.RazorPage.Services.Comments;
using Book.RazorPage.Services.Products;
using Book.RazorPage.Services.Sellers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book.RazorPage.Pages;

public class ProductModel : BaseRazorPage
{
    private readonly IProductService _service;
    private readonly ISellerService _sellerService;
    private ICommentService _commentService;
    public ProductModel(IProductService service, ISellerService sellerService, ICommentService commentService)
    {
        _service = service;
        _sellerService = sellerService;
        _commentService = commentService;
    }

    public SingleProductDto ProductPageModel { get; set; }


    public async Task<IActionResult> OnGet(string slug)
    {
        var product = await _service.GetSingleProduct(slug);
        if (product == null)
            return NotFound();

        ProductPageModel = product;
        return Page();
    }

    public async Task<IActionResult> OnPost(string slug, Guid productId, string comment)
    {
        if (User.Identity.IsAuthenticated == false)
            return Page();

        var result = await _commentService.AddComment(new AddCommentCommand()
        {
            ProductId = productId,
            Text = comment,
            UserId = User.GetUserId()
        });
        if (result.IsSuccess == false)
        {
            ErrorAlert(result.MetaData.Message);
            return Page();
        }
        SuccessAlert("نظر شما ثبت شد ، بعد از تایید در سایت نمایش داده می شود");
        return RedirectToPage("Product", new { slug });
    }
    public async Task<IActionResult> OnGetProductComments(Guid productId, int pageId = 1)
    {
        var commentResult = await _commentService.GetProductComments(pageId, 14, productId);
        return Partial("Shared/Products/_Comments", commentResult);
    }
    public async Task<IActionResult> OnPostDeleteComment(Guid id)
    {
        return await AjaxTryCatch(() => _commentService.DeleteComment(id));
    }
}