using Book.RazorPage.Infrastructure.RazorUtils;
using Book.RazorPage.Models.Categories;
using Book.RazorPage.Services.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book.RazorPage.Pages.Admin.Categories
{
    public class IndexModel : BaseRazorPage
    {
        private readonly ICategoryService _categoryService;

        public IndexModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public List<CategoryDto> Categories { get; set; }
        public async Task OnGet()
        {
            Categories = await _categoryService.GetCategories();
        }

        public async Task<IActionResult> OnPostDelete(Guid id)
        {
            return await AjaxTryCatch(() => _categoryService.DeleteCategory(id));
        }
    }
}
