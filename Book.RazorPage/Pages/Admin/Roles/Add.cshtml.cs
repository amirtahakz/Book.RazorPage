using System.ComponentModel.DataAnnotations;
using Book.RazorPage.Infrastructure.RazorUtils;
using Book.RazorPage.Infrastructure.Utils;
using Book.RazorPage.Models.Roles;
using Book.RazorPage.Services.Roles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book.RazorPage.Pages.Admin.Roles;

[BindProperties]
public class AddModel : BaseRazorPage
{
    private readonly IRoleService _roleService;

    public AddModel(IRoleService roleService)
    {
        _roleService = roleService;
    }
    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Title { get; set; }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost(string[] permission)
    {
        var permissionModel = new List<Permission>();
        foreach (var item in permission)
        {
            try
            {
                permissionModel.Add(EnumUtils.ParseEnum<Permission>(item));
            }
            catch
            {
                // 
            }
        }
        var result = await _roleService.CreateRole(new CreateRoleCommand()
        {
            Title = Title,
            Permissions = permissionModel
        });
        return RedirectAndShowAlert(result, RedirectToPage("Index"));
    }
}