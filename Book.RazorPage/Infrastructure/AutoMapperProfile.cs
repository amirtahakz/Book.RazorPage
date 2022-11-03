using AutoMapper;
using Book.RazorPage.Models.UserAddress;
using Book.RazorPage.ViewModels.Users.Addresses;

namespace Book.RazorPage.Infrastructure;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateUserAddressCommand, CreateUserAddressViewModel>().ReverseMap();
        CreateMap<EditUserAddressViewModel, EditUserAddressCommand>().ReverseMap();
        CreateMap<AddressDto, EditUserAddressViewModel>().ReverseMap();
    }
}