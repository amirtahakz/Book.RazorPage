namespace Book.RazorPage.Models.Roles;

public class EditRoleCommand
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public List<Permission> Permissions { get; set; }
}