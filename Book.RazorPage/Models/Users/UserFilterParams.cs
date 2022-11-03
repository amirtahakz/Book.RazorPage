namespace Book.RazorPage.Models.Users;

public class UserFilterParams : BaseFilterParam
{
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public Guid? Id { get; set; }
}