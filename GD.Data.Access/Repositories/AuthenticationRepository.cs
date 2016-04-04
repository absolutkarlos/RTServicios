using System.Collections.Generic;
using GD.Models.Commons;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class AuthenticationRepository : IAuthenticationRepository
	{
		private IDataAccessContext DbContext { get; }

		public AuthenticationRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public bool ValidateUserExists(User user)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fuser_get", new Dictionary<string, object>
			{
				{
					@"_id", user.Id
				}
			}).IsGreaterThanZero();
		}

		public long ValidateUserAuthentication(User user)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fuser_validate", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", user.ToJson()
				}
			});
		}
	}
}