using System.Text.Json.Serialization;

namespace MyMiniPOS_Backend.RestApi.Features.Category.Model;

public enum CategoryResponseStatus
{
	Created,
	NotFound,
	Successful,
	Fail
}

public class CategoryResponseModel
{
	public bool IsSuccessful { get; set; }
	[JsonIgnore]
	public CategoryResponseStatus Status { get; set; }
	public string? Message { get; set; }
}
