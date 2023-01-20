using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCircle.API.Contracts;
using MyCircle.API.Data;
using MyCircle.API.DTOs;
using MyCircle.API.Entities;
using System.Security.Cryptography;
using System.Text;

namespace MyCircle.API.Controllers
{
	public class AccountsController : Controller
	{
		private readonly DataContext dataContext;
		private readonly ITokenService tokenService;

		public AccountsController(DataContext dataContext, ITokenService tokenService)
		{
			this.dataContext = dataContext;
			this.tokenService = tokenService;
		}

		[HttpPost("register")]
		public async Task<ActionResult<TokenUserDto>> Register(RegisterUserDto registerUserDto)
		{

			if (await UserExists(registerUserDto.UserName))
			{
				return BadRequest("Username is taken");
			}


			using var hmac = new HMACSHA512();



			var user = new AppUser
			{
				UserName = registerUserDto.UserName.ToLower(),
				PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerUserDto.Password)),
				PasswordSalt = hmac.Key
			};

			dataContext.Users.Add(user);
			await dataContext.SaveChangesAsync();

			return new TokenUserDto
			{
				UserName = user.UserName,
				Token = tokenService.CreateToken(user)
			};

		}

		[HttpPost("login")]
		public async Task<ActionResult<TokenUserDto>> Login(LoginDto loginDto)
		{
			var user = await dataContext.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Name);

			if (user == null)
			{
				return Unauthorized("Invalid username");
			}

			using var hmac = new HMACSHA512(user.PasswordSalt);

			var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

			for (int i = 0; i < computedHash.Length; i++)
			{
				if (computedHash[i] != user.PasswordHash[i])
				{
					return Unauthorized("Invalid password");
				}
			}

			return new TokenUserDto
			{
				UserName = user.UserName,
				Token = tokenService.CreateToken(user)
			};
		}


		private async Task<bool> UserExists(string username)
		{
			return await dataContext.Users.AnyAsync(x => x.UserName == username.ToLower());
		}
	}
}
