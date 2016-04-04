using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class AuditRepository: IRepository<Audit>
	{
		private IDataAccessContext DbContext { get; }

		public AuditRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(Audit model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.faudit_set", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public void Delete<TId>(TId id)
		{

		}

		public void Update(Audit model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.faudit_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<Audit> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<Audit>>(@"rtsurvey.faudit_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public Audit GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Audit>>(@"rtsurvey.faudit_get", new Dictionary<string, object>
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
