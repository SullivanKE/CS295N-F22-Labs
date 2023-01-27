﻿using System.ComponentModel.DataAnnotations;
namespace KatieSite.Models
{
	public class LoginVM
	{
		[Required(ErrorMessage = "Please enter a username.")]
		[StringLength(255)]
		public string Username { get; set; } = string.Empty;
		[Required(ErrorMessage = "Please enter a password.")]
		[StringLength(255)]
		public string Password { get; set; } = string.Empty; 
		public string ReturnUrl { get; set; } = string.Empty; 
		public bool RememberMe { get; set; }
	}

}
