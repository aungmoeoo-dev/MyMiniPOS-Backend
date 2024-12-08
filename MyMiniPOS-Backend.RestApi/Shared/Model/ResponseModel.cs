namespace MyMiniPOS_Backend.RestApi.Shared.Model;

public class ResponseModel<T>
{
	public bool IsSuccessful { get; set; }
	public string? Message { get; set; }
	public T? Data { get; set; }
}
