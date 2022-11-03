using Book.RazorPage.Models;
using Book.RazorPage.Models.Users;
using Book.RazorPage.Models.Users.Commands;

namespace Book.RazorPage.Services.Users;

public interface IUserService
{
    Task<ApiResult> CreateUser(CreateUserCommand command);
    Task<ApiResult> EditUser(EditUserCommand command);
    Task<ApiResult> EditUserCurrent(EditUserCommand command);
    Task<ApiResult> ChangePassword(ChangePasswordCommand command);

    Task<UserDto?> GetUserById(Guid userId);
    Task<UserDto?> GetCurrentUser();
    Task<UserFilterResult> GetUsersByFilter(UserFilterParams filterParams);
}