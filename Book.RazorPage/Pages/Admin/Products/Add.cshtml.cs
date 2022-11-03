using System.ComponentModel.DataAnnotations;
using Book.RazorPage.Infrastructure.RazorUtils;
using Book.RazorPage.Infrastructure.Utils.CustomValidation.IFormFile;
using Book.RazorPage.Models.Products.Commands;
using Book.RazorPage.Services.Products;
using Book.RazorPage.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Book.RazorPage.Pages.Admin.Products;

[BindProperties]
public class AddModel : BaseRazorPage
{
    private readonly IProductService _productService;

    public AddModel(IProductService productService)
    {
        _productService = productService;
    }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Title { get; set; }

    [Display(Name = "عکس محصول")]
    [FileImage(ErrorMessage = "عکس نامعتبر است")]
    public IFormFile ImageFile { get; set; }

    [Display(Name = "توضیحات")]
    [UIHint("Ckeditor4")]
    public string Description { get; set; }

    [Display(Name = "دسته بندی")]
    public Guid CategoryId { get; set; }

    [Display(Name = "زیردسته بندی")]
    public Guid SubCategoryId { get; set; }

    [Display(Name = "دسته بندی سوم")]
    public Guid? SecondarySubCategoryId { get; set; }

    [Display(Name = "slug")]
    public string Slug { get; set; }


    public SeoDataViewModel SeoData { get; set; }

    public List<string> Keys { get; set; } = new();
    public List<string> Values { get; set; } = new();
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {

        var result = await _productService.CreateProduct(new CreateProductCommand()
        {
            CategoryId = CategoryId,
            Description = Description,
            ImageFile = ImageFile,
            SecondarySubCategoryId = SecondarySubCategoryId,
            SeoData = SeoData.MapToSeoData(),
            Slug = Slug,
            Specifications = ConvertSpecifications(),
            SubCategoryId = SubCategoryId,
            Title = Title
        });

        return RedirectAndShowAlert(result, RedirectToPage("Index"));
    }
    private Dictionary<string, string> ConvertSpecifications()
    {
        var specifications = new Dictionary<string, string>();
        Keys.RemoveAll(r => r == null || string.IsNullOrWhiteSpace(r));
        Values.RemoveAll(r => r == null || string.IsNullOrWhiteSpace(r));
        for (var i = 0; i < Keys.Count; i++)
        {
            specifications.Add(Keys[i], Values[i]);
        }

        return specifications;
    }
}