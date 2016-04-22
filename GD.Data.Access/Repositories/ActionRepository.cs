using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons.Utilities;
using NpgsqlTypes;
using Action = GD.Models.Commons.Action;

namespace GD.Data.Access.Repositories
{
	public class ActionRepository : IRepository<Action>
	{
		private IDataAccessContext DbContext { get; }

		public ActionRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(Action model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.faction_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(Action model)
		{
			DbContext.ExecuteStoredProcedure<Action>(@"rtsurvey.faction_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<Action> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<Action>>(@"rtsurvey.faction_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public Action GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Action>>(@"rtsurvey.faction_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = id }
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