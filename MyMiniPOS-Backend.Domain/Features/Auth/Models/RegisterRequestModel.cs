﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMiniPOS_Backend.Domain.Features.Auth.Models;

public class RegisterRequestModel
{
	public string Username { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
}
