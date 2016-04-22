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
	public class RadioBaseLineSightRepository : IRepository<RadioBaseLineSight>
	{
		private IDataAccessContext DbContext { get; }

		public RadioBaseLineSightRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(RadioBaseLineSight model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fradiobaselinesight_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(RadioBaseLineSight model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fradiobaselinesight_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<RadioBaseLineSight> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<RadioBaseLineSight>>(@"rtsurvey.fradiobaselinesight_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public RadioBaseLineSight GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<RadioBaseLineSight>>(@"rtsurvey.fradiobaselinesight_get", new List<Parameter>
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