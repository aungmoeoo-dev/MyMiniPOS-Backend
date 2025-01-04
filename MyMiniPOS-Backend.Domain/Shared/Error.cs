using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniPOS_Backend.Domain.Shared;

public sealed record Error(int Code, string Message)
{
	public static readonly Error None = new(default, string.Empty);
	public static Error NotFound(string message = "Content not found.") => new(404, message);
	public static Error SystemError(string message = "") => new(500, message);
}