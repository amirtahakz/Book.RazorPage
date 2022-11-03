using Book.RazorPage.Models;

namespace Book.RazorPage.Models.Sliders;

public class SliderDto : BaseDto
{
    public string Title { get; set; }
    public string Link { get; set; }
    public string ImageName { get; set; }
}

public class CreateSliderCommand
{
    public string Link { get; set; }
    public IFormFile ImageFile { get; set; }
    public string Title { get; set; }
}
public class EditSliderCommand
{
    public Guid Id { get; set; }
    public string Link { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string Title { get; set; }
}