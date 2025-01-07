using MyMiniPOS_Backend.Domain.Entities;
using MyMiniPOS_Backend.Domain.Shared;

namespace MyMiniPOS_Backend.Domain.Abstractions.Database;

public interface IUserDb
{
	public Task<Result<UserEntity>> FindUserByEmail(string message);
	public Task<Result<UserEntity>> InsertUser(UserEntity userEntity);
}
