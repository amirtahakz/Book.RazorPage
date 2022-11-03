using Book.RazorPage.Models;

namespace Book.RazorPage.Models.Categories;

public class CategoryDto : BaseDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public List<ChildCategoryDto> Childs { get; set; }
}
public class ChildCategoryDto : BaseDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public Guid ParentId { get; set; }
    public List<SecondaryChildCategoryDto> Childs { get; set; }
}
public class SecondaryChildCategoryDto : BaseDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public Guid ParentId { get; set; }
}