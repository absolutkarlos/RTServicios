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
	public class ClientTypeRepository : IRepository<ClientType>
	{
		private IDataAccessContext DbContext { get; }

		public ClientTypeRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(ClientType model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fclienttype_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(ClientType model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fclienttype_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<ClientType> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<ClientType>>(@"rtsurvey.fclienttype_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public ClientType GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<ClientType>>(@"rtsurvey.fclienttype_get", new List<Parameter>
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