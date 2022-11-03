﻿namespace Book.RazorPage.Models.Sellers.Commands;

public class AddSellerInventoryCommand
{
    public Guid SellerId { get; set; }
    public Guid ProductId { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public int? PercentageDiscount { get; set; }
}