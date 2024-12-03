using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMiniPOS_Backend.RestApi.Features.Category.Model;

[Table("TBL_Category")]
public class CategoryModel
{
	[Key]
	[Column("CategoryId")]
	public string? Id { get; set; }
	[Column("CategoryId")]
	public string? Name { get; set; }
	[Column("CategoryId")]
	public string? Description { get; set; }
}
