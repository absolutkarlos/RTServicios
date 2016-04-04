using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class RolActionRepository : IRepository<RolAction>
	{
		private IDataAccessContext DbContext { get; }

		public RolActionRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(RolAction model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.frolaction_set", new Dictionary<string, object>
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

		public void Update(RolAction model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.frolaction_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<RolAction> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<RolAction>>(@"rtsurvey.frolaction_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public RolAction GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<RolAction>>(@"rtsurvey.frolaction_get", new Dictionary<string, object>
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