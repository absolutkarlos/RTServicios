using GD.Models.Commons;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;

namespace GD.Core.Business
{
	public class AuthenticationBl : IAuthenticationBl
	{
		private IAuthenticationRepository Repository { get; set; }

		public AuthenticationBl(IAuthenticationRepository repository)
		{
			Repository = repository;
		}

		public bool IsAuthenticated(User user)
		{
			return Repository.ValidateUserExists(user);
		}

		public long ValidateAutentication(User user)
		{
			return Repository.ValidateUserAuthentication(user);
		}
	}
}