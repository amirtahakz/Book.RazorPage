using Book.RazorPage.Models;
using Book.RazorPage.Models.Categories;

namespace Book.RazorPage.Services.Categories;

public interface ICategoryService
{
    Task<ApiResult> CreateCategory(CreateCategoryCommand command);
    Task<ApiResult> EditCategory(EditCategoryCommand command);
    Task<ApiResult> DeleteCategory(Guid categoryId);
    Task<ApiResult> AddChild(AddChildCategoryCommand command);

    Task<CategoryDto?> GetCategoryById(Guid categoryId);
    Task<List<CategoryDto>> GetCategories();
    Task<List<ChildCategoryDto>> GetChild(Guid parentCategoryId);

}