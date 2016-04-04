using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class SiteRepository : ISiteRepository
	{
		private IDataAccessContext DbContext { get; }

		public SiteRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(Site model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fsite_set", new Dictionary<string, object>
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

		public void Update(Site model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fsite_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<Site> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<Site>>(@"rtsurvey.fsite_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public Site GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Site>>(@"rtsurvey.fsite_get", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
			}).FirstOrDefault();
		}

		public IEnumerable<Site> GetByClient<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Site>>(@"rtsurvey.fsitebyclient_get", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
			});
		}

		public void UpdateBuildingInformation(Site model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fsitebyidsite_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
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