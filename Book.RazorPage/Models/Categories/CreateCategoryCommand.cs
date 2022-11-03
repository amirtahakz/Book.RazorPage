namespace Book.RazorPage.Models.Categories;

public class CreateCategoryCommand
{
    public string Slug { get; set; }
    public string Title { get; set; }
    public SeoData SeoData { get; set; }
}
public class EditCategoryCommand
{
    public Guid Id { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; }
    public SeoData SeoData { get; set; }
}
public class AddChildCategoryCommand
{
    public Guid ParentId { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; }
    public SeoData SeoData { get; set; }
}