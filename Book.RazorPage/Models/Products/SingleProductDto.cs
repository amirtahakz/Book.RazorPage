using Book.RazorPage.Models.Sellers;
using Newtonsoft.Json;

namespace Book.RazorPage.Models.Products;

public class SingleProductDto
{
    public ProductDto ProductDto { get; set; }
    public List<InventoryDto> Inventories { get; set; }
}