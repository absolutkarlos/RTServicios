using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

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
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fsiteschedule_set", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(SiteSchedule model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fsiteschedule_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<SiteSchedule> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<SiteSchedule>>(@"rtsurvey.fsiteschedule_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public SiteSchedule GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<SiteSchedule>>(@"rtsurvey.fsiteschedule_get", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
			}).FirstOrDefault();
		}

		public IEnumerable<SiteSchedule> GetBySite<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<SiteSchedule>>(@"rtsurvey.fsiteschedulebysite_get", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
			});
		}

		public void DeleteBySite<TId>(TId id)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fsiteschedulebyidsite_delete", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
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