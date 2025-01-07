using Microsoft.EntityFrameworkCore;
using MyMiniPOS_Backend.Database;
using MyMiniPOS_Backend.Database.Repositories;
using MyMiniPOS_Backend.Domain.Abstractions.Database;
using MyMiniPOS_Backend.Domain.Abstractions.Services;
using MyMiniPOS_Backend.Domain.Features.Auth;
using MyMiniPOS_Backend.MinimalApi.Features.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
{
	if (!optionsBuilder.IsConfigured)
	{
		optionsBuilder.UseSqlServer();
	}
});

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserDb, UserDb>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthEndpoint();

app.Run();
