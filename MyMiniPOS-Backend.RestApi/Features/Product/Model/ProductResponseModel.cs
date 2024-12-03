using System.Text.Json.Serialization;

namespace MyMiniPOS_Backend.RestApi.Features.Product.Model;

public enum ProductResponseStatus
{
	Created,
	NotFound,
	Successful,
	Fail
}

public class ProductResponseModel
{
	public bool IsSuccessful { get; set; }
	[JsonIgnore]
	public ProductResponseStatus Status { get; set; }
	public string? Message { get; set; }
}

