using Microsoft.EntityFrameworkCore;
using MyMiniPOS_Backend.Database.Tables;
using MyMiniPOS_Backend.Domain.Abstractions.Repositories;
using MyMiniPOS_Backend.Domain.Entities;
using MyMiniPOS_Backend.Domain.Shared;

namespace MyMiniPOS_Backend.Database.Repositories;

public class UserRepository : IUserRepository
{
	private AppDbContext _context;
	public UserRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task<Result<UserEntity>> FindUserByEmail(string email)
	{
		try
		{
			var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
			if (user is null) return Error.NotFound();

			UserEntity userEntity = new()
			{
				Id = user.Id,
				Username = user.Username,
				Email = user.Email,
				Password = user.Password
			};

			return userEntity;
		}
		catch (Exception ex)
		{
			return Error.SystemError(ex.Message);
		}

	}

	public async Task<Result<UserEntity>> InsertUser(UserEntity userEntity)
	{
		TBLUser user = new()
		{
			Id = userEntity.Id,
			Username = userEntity.Username,
			Email = userEntity.Email,
			Password = userEntity.Password
		};

		try
		{
			await _context.Users.AddAsync(user);
			await _context.SaveChangesAsync();
			return userEntity;
		}
		catch (Exception ex)
		{
			return Error.SystemError(ex.Message);
		}
	}
}
