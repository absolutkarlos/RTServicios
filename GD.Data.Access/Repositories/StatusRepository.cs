using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class StatusRepository : IRepository<Status>
	{
		private IDataAccessContext DbContext { get; }

		public StatusRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(Status model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fstatus_set", new Dictionary<string, object>
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

		public void Update(Status model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fstatus_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<Status> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<Status>>(@"rtsurvey.fstatus_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public Status GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Status>>(@"rtsurvey.fstatus_get", new Dictionary<string, object>
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