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
	public class LineSightRepository : ILineSightRepository
	{
		private IDataAccessContext DbContext { get; }

		public LineSightRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(LineSight model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.flinesight_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(LineSight model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.flinesight_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<LineSight> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<LineSight>>(@"rtsurvey.flinesight_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public LineSight GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<LineSight>>(@"rtsurvey.flinesight_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = id }
			}).FirstOrDefault();
		}

		public IEnumerable<LineSight> GetBySite<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<LineSight>>(@"rtsurvey.flinesightbyidsite_get", new List<Parameter>
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