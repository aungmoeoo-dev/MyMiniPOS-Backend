using MyMiniPOS_Backend.Domain.Features.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniPOS_Backend.Domain.Abstractions.Services;

public interface IAuthService
{
	public Task<RegisterResponseModel> RegisterUser(RegisterRequestModel request);
}
