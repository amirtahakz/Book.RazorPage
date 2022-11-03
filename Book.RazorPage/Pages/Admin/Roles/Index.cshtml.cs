using Book.RazorPage.Infrastructure.RazorUtils;
using Book.RazorPage.Models.Roles;
using Book.RazorPage.Services.Roles;
using Microsoft.AspNetCore.Mvc;

namespace Book.RazorPage.Pages.Admin.Roles
{
    public class IndexModel : BaseRazorPage
    {
        private IRoleService _roleService;

        public IndexModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public List<RoleDto> Roles { get; set; }
        public async Task OnGet()
        {
            Roles = await _roleService.GetRoles();
        }
    }
}
