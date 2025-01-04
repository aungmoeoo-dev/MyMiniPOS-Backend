using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniPOS_Backend.Domain.Shared.Models;

public class BaseResponseModel
{
	public bool Success { get; set; }
	public string Message { get; set; }
}
