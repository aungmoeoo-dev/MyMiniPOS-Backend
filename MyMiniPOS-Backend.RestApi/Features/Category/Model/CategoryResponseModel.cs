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
	public CategoryResponseStatus Status { get; set; }
	public string? Message { get; set; }
}
