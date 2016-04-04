using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class StateRepository : IStateRepository
	{
		private IDataAccessContext DbContext { get; }

		public StateRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(State model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fstate_set", new Dictionary<string, object>
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

		public void Update(State model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fstate_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<State> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<State>>(@"rtsurvey.fstate_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public State GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<State>>(@"rtsurvey.fstate_get", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
			}).FirstOrDefault();
		}

		public IEnumerable<State> GetByCountry<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<State>>(@"rtsurvey.fstatebyidcountry_get", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
			});
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