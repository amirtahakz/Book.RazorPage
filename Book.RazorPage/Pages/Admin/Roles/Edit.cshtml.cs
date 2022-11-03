using System.ComponentModel.DataAnnotations;
using Book.RazorPage.Infrastructure.RazorUtils;
using Book.RazorPage.Models.Roles;
using Book.RazorPage.Services.Roles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book.RazorPage.Pages.Admin.Roles;

[BindProperties]
public class EditModel : BaseRazorPage
{
    private readonly IRoleService _roleService;

    public EditModel(IRoleService roleService)
    {
        _roleService = roleService;
    }
    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Title { get; set; }

    public List<Permission> Permissions { get; set; }
    public async Task<IActionResult> OnGet(Guid id)
    {
        var role = await _roleService.GetRoleById(id);
        if (role == null)
            return RedirectToPage("Index");

        Title = role.Title;
        Permissions = role.Permissions;
        return Page();
    }

    public async Task<IActionResult> OnPost(Guid id, List<Permission> permissions)
    {
        var result = await _roleService.EditRole(new EditRoleCommand()
        {
            Title = Title,
            Permissions = permissions,
            Id = id
        });
        return RedirectAndShowAlert(result, RedirectToPage("Index"), RedirectToPage("Edit", new { id }));
    }
}