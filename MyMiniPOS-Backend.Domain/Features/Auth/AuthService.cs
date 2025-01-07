using MyMiniPOS_Backend.Domain.Abstractions.Database;
using MyMiniPOS_Backend.Domain.Abstractions.Services;
using MyMiniPOS_Backend.Domain.Features.Auth.Models;


namespace MyMiniPOS_Backend.Domain.Features.Auth;

public class AuthService : IAuthService
{
	private readonly IUserDb _userRepository;
	public AuthService(IUserDb userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<RegisterResponseModel> RegisterUser(RegisterRequestModel requestModel)
	{
		RegisterResponseModel responseModel = new();

		var userResult = await _userRepository.FindUserByEmail(requestModel.Email);

		responseModel.User = userResult.Data;
		return responseModel;
	}
}
