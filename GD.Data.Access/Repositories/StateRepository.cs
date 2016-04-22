using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;
using NpgsqlTypes;

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
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fstate_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(State model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fstate_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<State> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<State>>(@"rtsurvey.fstate_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public State GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<State>>(@"rtsurvey.fstate_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = id }
			}).FirstOrDefault();
		}

		public IEnumerable<State> GetByCountry<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<State>>(@"rtsurvey.fstatebyidcountry_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = id }
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