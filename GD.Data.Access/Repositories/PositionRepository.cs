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
	public class PositionRepository : IRepository<Position>
	{
		private IDataAccessContext DbContext { get; }

		public PositionRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(Position model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fposition_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(Position model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fposition_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<Position> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<Position>>(@"rtsurvey.fposition_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public Position GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Position>>(@"rtsurvey.fposition_get", new List<Parameter>
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