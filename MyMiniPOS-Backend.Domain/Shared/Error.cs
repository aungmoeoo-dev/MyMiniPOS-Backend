using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniPOS_Backend.Domain.Shared;

public sealed record Error(int Code, string Message)
{
	public static readonly Error None = new(default, string.Empty);
}
