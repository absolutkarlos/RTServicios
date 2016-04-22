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
	public class RadioBaseRepository : IRepository<RadioBase>
	{
		private IDataAccessContext DbContext { get; }

		public RadioBaseRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(RadioBase model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fradiobase_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(RadioBase model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fradiobase_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<RadioBase> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<RadioBase>>(@"rtsurvey.fradiobase_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public RadioBase GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<RadioBase>>(@"rtsurvey.fradiobase_get", new List<Parameter>
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