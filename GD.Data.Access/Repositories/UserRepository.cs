using System;
using System.Collections.Generic;
using System.Linq;
using GD.Models.Commons;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class UserRepository : IRepository<User>
	{
		private IDataAccessContext DbContext { get; }

		public UserRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(User model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fuser_set", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(User model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fuser_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<User> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<User>>(@"rtsurvey.fuser_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public User GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<User>>(@"rtsurvey.fuser_get", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
			}).FirstOrDefault();
		}

		public bool Exists<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
