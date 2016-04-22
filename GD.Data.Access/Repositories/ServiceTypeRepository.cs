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
	public class ServiceTypeRepository : IRepository<ServiceType>
	{
		private IDataAccessContext DbContext { get; }

		public ServiceTypeRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(ServiceType model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fservicetype_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(ServiceType model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fservicetype_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<ServiceType> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<ServiceType>>(@"rtsurvey.fservicetype_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public ServiceType GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<ServiceType>>(@"rtsurvey.fservicetype_get", new List<Parameter>
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