using System.Collections.Generic;
using GD.Models.Commons;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons.Utilities;
using NpgsqlTypes;

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
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fuser_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = user.Id }
			}).IsGreaterThanZero();
		}

		public long ValidateUserAuthentication(User user)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fuser_validate", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = user.ToJson() }
			});
		}
	}
}