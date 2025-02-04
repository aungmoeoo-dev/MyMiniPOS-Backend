namespace MyMiniPOS_Backend.Shared;

public class Result<T>
{
	public T Data { get; set; }

	public Error Error { get; set; }

	public static Result<T> Success(T data) => new() { Data = data };

	public static Result<T> Failure (Error error) => new() { Error = error };
}
