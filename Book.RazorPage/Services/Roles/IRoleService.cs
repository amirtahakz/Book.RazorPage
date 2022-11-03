using Book.RazorPage.Models;
using Book.RazorPage.Models.Roles;

namespace Book.RazorPage.Services.Roles;

public interface IRoleService
{
    Task<ApiResult> CreateRole(CreateRoleCommand command);
    Task<ApiResult> EditRole(EditRoleCommand command);
    Task<RoleDto> GetRoleById(Guid roleId);
    Task<List<RoleDto>> GetRoles();
}