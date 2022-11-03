using Book.RazorPage.Models;
using Book.RazorPage.Models.Sliders;

namespace Book.RazorPage.Services.Sliders;

public interface ISliderService
{
    Task<ApiResult> CreateSlider(CreateSliderCommand command);
    Task<ApiResult> EditSlider(EditSliderCommand command);
    Task<ApiResult> DeleteSlider(Guid sliderId);

    Task<SliderDto?> GetSliderById(Guid sliderId);
    Task<List<SliderDto>> GetSliders();
}