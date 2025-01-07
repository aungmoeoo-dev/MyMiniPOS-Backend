using MyMiniPOS_Backend.Domain.Abstractions.Database;
using MyMiniPOS_Backend.Domain.Abstractions.Services;
using MyMiniPOS_Backend.Domain.Entities;
using MyMiniPOS_Backend.Domain.Features.Auth.Models;


namespace MyMiniPOS_Backend.Domain.Features.Auth;

public class AuthService : IAuthService
{
	private readonly IUserDb _userDb;
	private readonly ITokenService _tokenService;

	public AuthService(IUserDb userDb, ITokenService tokenService)
	{
		_userDb = userDb;
		_tokenService = tokenService;
	}

	public async Task<RegisterResponseModel> RegisterUser(RegisterRequestModel requestModel)
	{
		RegisterResponseModel responseModel = new();

		var userResult = await _userDb.FindUserByUsername(requestModel.Username);
		if (userResult.IsFailure)
		{
			responseModel.Success = userResult.IsSuccess;
			responseModel.Message = userResult.Error.Message;
			return responseModel;
		}

		var user = new UserEntity
		{
			Id = Guid.NewGuid().ToString(),
			Username = requestModel.Username,
			Password = requestModel.Password,
		};
		//var insertResult = await _userDb.InsertUser(user);
		//if (insertResult.IsFailure)
		//{
		//	responseModel.Success = insertResult.IsSuccess;
		//	responseModel.Message = insertResult.Error.Message;
		//	return responseModel;
		//}

		responseModel.AccessToken = _tokenService.CreateAccessToken(user);
		responseModel.User = userResult.Data;
		return responseModel;
	}
}
