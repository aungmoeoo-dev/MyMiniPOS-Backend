using MyMiniPOS_Backend.Domain.Entities;
using MyMiniPOS_Backend.Domain.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniPOS_Backend.Domain.Features.Auth.Models;

public class LoginResponseModel : BaseResponseModel
{
	public UserEntity User { get; set; }
	public string AccessToken { get; set; }
	public string RefreshToken { get; set; }
}
