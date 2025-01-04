using Microsoft.AspNetCore.Mvc;
using MyMiniPOS_Backend.Domain.Abstractions.Services;
using MyMiniPOS_Backend.Domain.Features.Auth.Models;

namespace MyMiniPOS_Backend.MinimalApi.Features.Auth;

public static class AuthEndpoint
{

	public static IEndpointRouteBuilder UseAuthEndpoint(this IEndpointRouteBuilder app)
	{
		app.MapPost("/api/auth/register", async ([FromBody]RegisterRequestModel requestModel, IAuthService authService) =>
		{
			var responseModel = await authService.RegisterUser(requestModel);
			if (!responseModel.Success) return Results.BadRequest(responseModel);

			return Results.Ok(responseModel);
		}).WithName("Register user")
		.WithOpenApi(); ;

		return app;
	}
}
