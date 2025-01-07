using System.Text.Json.Serialization;

namespace MyMiniPOS_Backend.Domain.Entities;

public class UserEntity
{
	[JsonPropertyName("id")]
	public string Id { get; set; }
	[JsonPropertyName("username")]
	public string Username { get; set; }
	[JsonPropertyName("password")]
	public string Password { get; set; }
}
