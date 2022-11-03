using Book.RazorPage.Infrastructure.RazorUtils;
using Book.RazorPage.Models.Banners;
using Book.RazorPage.Models;
using Book.RazorPage.Models.Users;
using Book.RazorPage.Models.Users.Commands;
using Book.RazorPage.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book.RazorPage.Pages.Admin.Users
{
    public class IndexModel : BaseRazorFilter<UserFilterParams>
    {
        private readonly IUserService _userService;
        private IRenderViewToString _renderView;

        public IndexModel(IUserService userService, IRenderViewToString renderView)
        {
            _userService = userService;
            _renderView = renderView;
        }

        public UserFilterResult FilterResult { get; set; }
        public async Task OnGet()
        {
            FilterResult = await _userService.GetUsersByFilter(FilterParams);
        }
        public async Task<IActionResult> OnGetRenderAddPage()
        {
            return await AjaxTryCatch(async () =>
            {
                var view = await _renderView.RenderToStringAsync("_Add", new CreateUserCommand(), PageContext);
                return ApiResult<string>.Success(view);
            });
        }
        public async Task<IActionResult> OnGetRenderEditPage(Guid id)
        {

            return await AjaxTryCatch(async () =>
            {
                var user = await _userService.GetUserById(id);
                if (user == null)
                    return ApiResult<string>.Error();

                var model = new EditUserCommand()
                {
                    UserId = id,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    Family = user.Family,
                    Name = user.Name,
                    Gender = user.Gender
                };
                var view = await _renderView.RenderToStringAsync("_Edit", model, PageContext);
                return ApiResult<string>.Success(view);
            });
        }
        public async Task<IActionResult> OnPostCreateUser(CreateUserCommand command)
        {
            return await AjaxTryCatch(() =>
                _userService.CreateUser(command));
        }
        public async Task<IActionResult> OnPostEditUser(EditUserCommand command)
        {
            return await AjaxTryCatch(() =>
                _userService.EditUser(command));
        }
    }
}
