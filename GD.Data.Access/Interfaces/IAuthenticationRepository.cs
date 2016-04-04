using GD.Models.Commons;

namespace GD.Data.Access.Interfaces
{
	public interface IAuthenticationRepository
	{
		bool ValidateUserExists(User user);
		long ValidateUserAuthentication(User user);
	}
}