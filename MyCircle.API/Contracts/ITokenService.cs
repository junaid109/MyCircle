using MyCircle.API.Entities;

namespace MyCircle.API.Contracts
{
	public interface ITokenService
	{
		string CreateToken(AppUser user);
		
		
		
	}
}
