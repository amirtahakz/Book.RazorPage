using AutoMapper;
using Book.RazorPage.Infrastructure.RazorUtils;
using Book.RazorPage.Models;
using Book.RazorPage.Models.UserAddress;
using Book.RazorPage.Services.UserAddress;
using Book.RazorPage.ViewModels.Users.Addresses;
using Microsoft.AspNetCore.Mvc;

namespace Book.RazorPage.Pages.Profile.Addresses
{
    public class IndexModel : BaseRazorPage
    {
        private readonly IUserAddressService _userAddress;
        private readonly IRenderViewToString _renderViewToString;
        private IMapper _mapper;
        public IndexModel(IUserAddressService userAddress, IRenderViewToString renderViewToString, IMapper mapper)
        {
            _userAddress = userAddress;
            _renderViewToString = renderViewToString;
            _mapper = mapper;
        }

        public List<AddressDto> Addresses { get; set; }
        public async Task OnGet()
        {
            Addresses = await _userAddress.GetUserAddresses();
        }

        public async Task<IActionResult> OnPostAsync(Guid addressId)
        {
            var result = await _userAddress.DeleteAddress(addressId);
            return RedirectAndShowAlert(result, RedirectToPage("Index"), RedirectToPage("Index"));
        }
        public async Task<IActionResult> OnPostAddAddress(CreateUserAddressViewModel viewModel)
        {
            return await AjaxTryCatch(async () =>
            {
                var model = _mapper.Map<CreateUserAddressCommand>(viewModel);
                var result = await _userAddress.CreateAddress(model);

                return result;
            }, true);
        }
        public async Task<IActionResult> OnGetSetActiveAddress(Guid addressId)
        {
            return await AjaxTryCatch(async () =>
            {
                var result = await _userAddress.SetActiveAddress(addressId);
                return result;
            }, true);
        }
        public async Task<IActionResult> OnPostEditAddress(EditUserAddressViewModel viewModel)
        {
            return await AjaxTryCatch(async () =>
            {
                var model = _mapper.Map<EditUserAddressCommand>(viewModel);
                var result = await _userAddress.EditAddress(model);

                return result;
            }, true);
        }
        public async Task<IActionResult> OnGetShowAddPage()
        {
            return await AjaxTryCatch(async () =>
            {
                var view = await _renderViewToString.RenderToStringAsync("_Add", new CreateUserAddressViewModel(),
                    PageContext);

                return ApiResult<string>.Success(view);
            });
        }
        public async Task<IActionResult> OnGetShowEditPage(Guid addressId)
        {
            return await AjaxTryCatch(async () =>
            {
                var address = await _userAddress.GetAddressById(addressId);
                var model = _mapper.Map<EditUserAddressViewModel>(address);
                var view = await _renderViewToString.RenderToStringAsync("_Edit", model, PageContext);

                return ApiResult<string>.Success(view);
            });
        }

    }
}
