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
	public class UnitMeasureRepository : IRepository<UnitMeasure>
	{
		private IDataAccessContext DbContext { get; }

		public UnitMeasureRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(UnitMeasure model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.funitmeasure_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(UnitMeasure model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.funitmeasure_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<UnitMeasure> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<UnitMeasure>>(@"rtsurvey.funitmeasure_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public UnitMeasure GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<UnitMeasure>>(@"rtsurvey.funitmeasure_get", new List<Parameter>
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