using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class LineSightRepository : IRepository<LineSight>
	{
		private IDataAccessContext DbContext { get; }

		public LineSightRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(LineSight model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.flinesight_set", new Dictionary<string, object>
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

		public void Update(LineSight model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.flinesight_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<LineSight> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<LineSight>>(@"rtsurvey.flinesight_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public LineSight GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<LineSight>>(@"rtsurvey.flinesight_get", new Dictionary<string, object>
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