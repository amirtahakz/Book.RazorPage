using Book.RazorPage.Models;
using Book.RazorPage.Models.ShippingMethods;

namespace Book.RazorPage.Services.ShippingMethods;

public interface IShippingMethodService
{
    Task<List<ShippingMethodDto>> GetShippingMethods();
}

public class ShippingMethodService : IShippingMethodService
{
    private readonly HttpClient _client;
    private const string ModuleName = "ShippingMethod";
    public ShippingMethodService(HttpClient client)
    {
        _client = client;
    }
    public async Task<List<ShippingMethodDto>> GetShippingMethods()
    {
        var result = await _client.GetFromJsonAsync<ApiResult<List<ShippingMethodDto>>>($"{ModuleName}");
        return result?.Data ?? new();
    }
}