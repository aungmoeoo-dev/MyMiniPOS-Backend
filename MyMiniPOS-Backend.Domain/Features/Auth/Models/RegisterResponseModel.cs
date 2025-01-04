using MyMiniPOS_Backend.Domain.Entities;
using MyMiniPOS_Backend.Domain.Shared.Models;

namespace MyMiniPOS_Backend.Domain.Features.Auth.Models;

public class RegisterResponseModel : BaseResponseModel
{
	public UserEntity User { get; set; }
	public string AccessToken { get; set; }
	public string RefreshToken { get; set; }
}
