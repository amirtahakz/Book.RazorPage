﻿using System.ComponentModel.DataAnnotations;
using Book.RazorPage.Infrastructure.RazorUtils;
using Book.RazorPage.Infrastructure.Utils.CustomValidation.IFormFile;
using Book.RazorPage.Models.Sliders;
using Book.RazorPage.Services.Sliders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book.RazorPage.Pages.Admin.Sliders;

[BindProperties]
public class EditModel : BaseRazorPage
{
    private readonly ISliderService _service;

    public EditModel(ISliderService service)
    {
        _service = service;
    }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Title { get; set; }

    [Display(Name = "لینک")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [DataType(DataType.Url)]
    public string Link { get; set; }

    [Display(Name = "عکس اسلایدر")]
    [FileImage(ErrorMessage = "عکس نامعتبر است")]
    public IFormFile? ImageFile { get; set; }


    public string ImageName { get; set; }

    public async Task<IActionResult> OnGet(Guid id)
    {
        var slider = await _service.GetSliderById(id);
        if (slider == null)
            return RedirectToPage("Index");


        Title = slider.Title;
        Link = slider.Link;
        ImageName = slider.ImageName;

        return Page();
    }

    public async Task<IActionResult> OnPost(Guid id)
    {
        var result = await _service.EditSlider(new EditSliderCommand()
        {
            Id = id,
            Title = Title,
            ImageFile = ImageFile,
            Link = Link
        });
        return RedirectAndShowAlert(result, RedirectToPage("Index"));
    }
}