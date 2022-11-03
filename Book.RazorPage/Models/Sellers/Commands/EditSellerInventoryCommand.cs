using System.ComponentModel.DataAnnotations;

namespace Book.RazorPage.Models.Sellers.Commands;

public class EditSellerInventoryCommand
{
    public Guid SellerId { get; set; }
    public Guid InventoryId { get; set; }
    [Display(Name = "تعداد موجود")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public int Count { get; set; }

    [Display(Name = "مبلغ")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public int Price { get; set; }

    [Display(Name = "درصد تخفیف")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [Range(0, 100, ErrorMessage = "درصد تخفیف نامعتبر است")]
    public int DiscountPercentage { get; set; }
}