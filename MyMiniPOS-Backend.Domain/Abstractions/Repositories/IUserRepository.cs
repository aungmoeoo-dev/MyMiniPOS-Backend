using MyMiniPOS_Backend.Domain.Entities;
using MyMiniPOS_Backend.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniPOS_Backend.Domain.Abstractions.Repositories;

public interface IUserRepository
{
	public Task<Result<UserEntity>> FindUserByEmail(string message);
	public Task<Result<UserEntity>> InsertUser(UserEntity userEntity);
}
