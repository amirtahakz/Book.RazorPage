using Book.RazorPage.Models;
using Book.RazorPage.Models.UserAddress;

namespace Book.RazorPage.Services.UserAddress;

public interface IUserAddressService
{
    Task<ApiResult> CreateAddress(CreateUserAddressCommand command);
    Task<ApiResult> EditAddress(EditUserAddressCommand command);
    Task<ApiResult> DeleteAddress(Guid addressId);
    Task<ApiResult> SetActiveAddress(Guid addressId);

    Task<AddressDto?> GetAddressById(Guid id);
    Task<List<AddressDto>> GetUserAddresses();
}