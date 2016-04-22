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
	public class RolActionRepository : IRepository<RolAction>
	{
		private IDataAccessContext DbContext { get; }

		public RolActionRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(RolAction model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.frolaction_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(RolAction model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.frolaction_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<RolAction> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<RolAction>>(@"rtsurvey.frolaction_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public RolAction GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<RolAction>>(@"rtsurvey.frolaction_get", new List<Parameter>
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