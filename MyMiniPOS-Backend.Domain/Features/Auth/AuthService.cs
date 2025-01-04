using MyMiniPOS_Backend.Domain.Abstractions.Repositories;
using MyMiniPOS_Backend.Domain.Abstractions.Services;
using MyMiniPOS_Backend.Domain.Features.Auth.Models;
using MyMiniPOS_Backend.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniPOS_Backend.Domain.Features.Auth;

public class AuthService : IAuthService
{
	private readonly IUserRepository _userRepository;
	public AuthService(IUserRepository userRepository)
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
