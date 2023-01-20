using Microsoft.IdentityModel.Tokens;
using MyCircle.API.Contracts;
using MyCircle.API.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyCircle.API.Services
{
	public class TokenService : ITokenService
	{
		private readonly SymmetricSecurityKey symmetricSecurityKey;

		public TokenService(IConfiguration configuration)
		{
			symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(s: configuration["TokenKey"]));
		}

		public string CreateToken(AppUser user)
		{
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super secret key"));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddDays(7),
				SigningCredentials = creds
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);
		}
	}
}
