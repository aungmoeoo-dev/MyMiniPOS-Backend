using System.Text.Json.Serialization;

namespace MyMiniPOS_Backend.RestApi.Features.Product.Model;

public class ProductResponseModel
{
	public bool IsSuccessful { get; set; }
	public string? Message { get; set; }
}

