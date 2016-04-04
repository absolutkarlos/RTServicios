using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class ZoneRepository : IZoneRepository
	{
		private IDataAccessContext DbContext { get; }

		public ZoneRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(Zone model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fzone_set", new Dictionary<string, object>
			{
				{ @"_jsonvalue", model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(Zone model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fzone_update", new Dictionary<string, object>
			{
				{ @"_jsonvalue", model.ToJson() }
			});
		}

		public IEnumerable<Zone> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<Zone>>(@"rtsurvey.fzone_get", new Dictionary<string, object>
			{
				{ @"_id", 0 }
			});
		}

		public Zone GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Zone>>(@"rtsurvey.fzone_get", new Dictionary<string, object>
			{
				{ @"_id", id }
			}).FirstOrDefault();
		}

		public IEnumerable<Zone> GetByCity<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Zone>>(@"rtsurvey.fzonebyidcity_get", new Dictionary<string, object>
			{
				{ @"_id", id }
			});
		}

		public bool Exists<TId>(TId id)
		{
			return true;
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}