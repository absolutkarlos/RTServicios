using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class SiteAccessTypeRepository : ISiteAccessTypeRepository
	{
		private IDataAccessContext DbContext { get; }

		public SiteAccessTypeRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(SiteAccessType model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fsiteaccesstype_set", new Dictionary<string, object>
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

		public void Update(SiteAccessType model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fsiteaccesstype_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<SiteAccessType> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<SiteAccessType>>(@"rtsurvey.fsiteaccesstype_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public SiteAccessType GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<SiteAccessType>>(@"rtsurvey.fsiteaccesstype_get", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
			}).FirstOrDefault();
		}

		public IEnumerable<SiteAccessType> GetBySite<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<SiteAccessType>>(@"rtsurvey.fsiteaccesstypebyidsite_get", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
			});
		}

		public void DeleteBySite<TId>(TId id)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fsiteaccesstypebyidsite_delete", new Dictionary<string, object>
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