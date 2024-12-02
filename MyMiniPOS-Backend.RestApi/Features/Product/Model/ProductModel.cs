using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMiniPOS_Backend.RestApi.Features.Product.Model;

[Table("TBL_Product")]
public class ProductModel
{
    [Key]
    [Column("ProductId")]
    public string? Id { get; set; }
	[Column("ProductName")]
	public string? Name { get; set; }
	[Column("ProductImageUrl")]
	public string? ImageUrl { get; set; }
	[Column("ProductCategoryId")]
	public string? CategoryId { get; set; }
	[Column("ProductPrice")]
	public decimal Price { get; set; }
	[Column("ProductDiscountRate")]
	public decimal DiscountRate { get; set; }
}
