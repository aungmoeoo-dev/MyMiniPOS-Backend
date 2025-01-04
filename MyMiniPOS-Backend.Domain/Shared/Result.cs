using System.Reflection.Emit;

namespace MyMiniPOS_Backend.Domain.Shared;

public class Result<T>
{
	public T Data { get; set; }

	public Error Error { get; set; }

	public bool IsSuccess => Error is null;
	public bool IsFailure => !IsSuccess;

	public static implicit operator Result<T>(T data) => new() { Data = data, Error = Error.None };

	public static implicit operator Result<T>(Error error) => new() { Error = error };

}
