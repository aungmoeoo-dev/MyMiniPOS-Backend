using MyMiniPOS_Backend.Domain.Entities;
using MyMiniPOS_Backend.Domain.Shared;

namespace MyMiniPOS_Backend.Domain.Abstractions.Database;

public interface IUserDb
{
	public Task<Result<UserEntity>> FindUserByUsername(string username);
	public Task<Result<UserEntity>> InsertUser(UserEntity userEntity);
}
