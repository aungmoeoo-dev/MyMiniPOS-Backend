using MyMiniPOS_Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniPOS_Backend.Domain.Abstractions.Services;

public interface ITokenService
{
	public string CreateAccessToken(UserEntity userEntity);
}
