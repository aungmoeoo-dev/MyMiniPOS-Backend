using Microsoft.IdentityModel.Tokens;
using MyMiniPOS_Backend.Domain.Abstractions.Services;
using MyMiniPOS_Backend.Domain.Entities;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyMiniPOS_Backend.Domain.Services.Token;

public class TokenService : ITokenService
{
	private string _createJWT<T>(string secret, JWTHeader header, T payload, DateTime expireAt)
	{
		var headerJsonStr = JsonSerializer.Serialize(header);
		var headerByteArray = UTF8Encoding.UTF8.GetBytes(headerJsonStr);
		var firstPart = Base64UrlEncoder.Encode(headerByteArray);


		var unixTime = DateTimeOffset.Parse(expireAt.ToString()).ToUnixTimeSeconds();
		var expireNode = JsonSerializer.SerializeToNode(unixTime).AsValue();
		var payloadNode = JsonSerializer.SerializeToNode(payload).AsObject();
		payloadNode.Add("expireAt", expireNode);
		var payloadByteArray = UTF8Encoding.UTF8.GetBytes(payloadNode.ToJsonString(options: new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase}));
		var secondPart = Base64UrlEncoder.Encode(payloadByteArray);

		var combined = $"{firstPart}.{secondPart}";
		var signatureByteArray = HMACSHA256.HashData(UTF8Encoding.UTF8.GetBytes(secret), UTF8Encoding.UTF8.GetBytes(combined));
		var thirdPart = Base64UrlEncoder.Encode(signatureByteArray);

		return $"{firstPart}.{secondPart}.{thirdPart}";
	}
	public string CreateAccessToken(UserEntity userEntity)
	{
		JWTHeader header = new()
		{
			Algorithm = "HS256",
			Type = "JWT"
		};
		
		return _createJWT("secret", header, userEntity, DateTime.Now);
	}
}

class JWTHeader
{
	[JsonPropertyName("alg")]
	public string Algorithm { get; set; }
	[JsonPropertyName("typ")]
	public string Type { get; set; }
}