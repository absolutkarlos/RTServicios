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
	public class AuditRepository: IRepository<Audit>
	{
		private IDataAccessContext DbContext { get; }

		public AuditRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(Audit model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.faudit_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{

		}

		public void Update(Audit model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.faudit_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<Audit> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<Audit>>(@"rtsurvey.faudit_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public Audit GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Audit>>(@"rtsurvey.faudit_get", new List<Parameter>
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
