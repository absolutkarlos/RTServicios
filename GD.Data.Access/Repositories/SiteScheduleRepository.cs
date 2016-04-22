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
	public class SiteScheduleRepository : ISiteSheduleRepository
	{
		private IDataAccessContext DbContext { get; }

		public SiteScheduleRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(SiteSchedule model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fsiteschedule_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(SiteSchedule model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fsiteschedule_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<SiteSchedule> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<SiteSchedule>>(@"rtsurvey.fsiteschedule_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public SiteSchedule GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<SiteSchedule>>(@"rtsurvey.fsiteschedule_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = id }
			}).FirstOrDefault();
		}

		public IEnumerable<SiteSchedule> GetBySite<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<SiteSchedule>>(@"rtsurvey.fsiteschedulebysite_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = id }
			});
		}

		public void DeleteBySite<TId>(TId id)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fsiteschedulebyidsite_delete", new List<Parameter>
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