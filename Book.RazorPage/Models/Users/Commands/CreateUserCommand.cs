using Book.RazorPage.Infrastructure.Utils.CustomValidation.IFormFile;
using System.ComponentModel.DataAnnotations;

namespace Book.RazorPage.Models.Users.Commands;

public class CreateUserCommand
{
    [Display(Name = "نام")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Name { get; set; }

    [Display(Name = "نام خانوادگی")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Family { get; set; }

    [Display(Name = "شماره تلفن")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string PhoneNumber { get; set; }

    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Email { get; set; }

    [Display(Name = "کلمه عبور")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Password { get; set; }

    [Display(Name = "جنسیت")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public Gender Gender { get; set; }
}
public class EditUserCommand
{
    public Guid UserId { get; set; }

    [Display(Name = "نام")]
    public string Name { get; set; }

    [Display(Name = "نام خانوادگی")]
    public string Family { get; set; }

    [Display(Name = "شماره تلفن")]
    public string PhoneNumber { get; set; }

    [Display(Name = "ایمیل")]
    public string Email { get; set; }

    [Display(Name = "کلمه عبور")]
    public string? Password { get; set; }

    [Display(Name = "جنسیت")]
    public Gender Gender { get; set; }

    [FileImage(ErrorMessage = "عکس نامعتبر است")]
    public IFormFile? Avatar { get; set; }
}