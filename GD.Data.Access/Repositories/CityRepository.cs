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
	public class CityRepository : ICityRepository
	{
		private IDataAccessContext DbContext { get; }

		public CityRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(City model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fcity_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(City model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fcity_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<City> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<City>>(@"rtsurvey.fcity_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public City GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<City>>(@"rtsurvey.fcity_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = id }
			}).FirstOrDefault();
		}

		public IEnumerable<City> GetByState<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<City>>(@"rtsurvey.fcitybyidstate_get", new List<Parameter>
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