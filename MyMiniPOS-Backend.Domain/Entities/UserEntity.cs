﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMiniPOS_Backend.Domain.Entities;

public class UserEntity
{
	public string Id { get; set; }
	public string Username { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
}
