using GD.Models.Commons;

namespace GD.Core.Business.Interfaces
{
	public interface IAuthenticationBl
	{
		bool IsAuthenticated(User user);
		long ValidateAutentication(User user);
	}
}