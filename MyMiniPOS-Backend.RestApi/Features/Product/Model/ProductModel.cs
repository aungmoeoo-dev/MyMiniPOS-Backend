using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMiniPOS_Backend.RestApi.Features.Product.Model;

[Table("TBL_Product")]
public class ProductModel
{
    [Key]
    public Guid ProductId { get; set; }
    public string? ProductName { get; set; }
    public string? ProductImageUrl { get; set; }
    public Guid ProductCategoryId { get; set; }
    public decimal ProductPrice { get; set; }
    public decimal ProductDiscountRate { get; set; }
}
