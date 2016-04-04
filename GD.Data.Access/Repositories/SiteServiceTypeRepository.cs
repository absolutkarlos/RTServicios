using System;
using System.Collections.Generic;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class SiteServiceTypeRepository : ISiteServiceTypeRepository
	{
		private IDataAccessContext DbContext { get; }

		public SiteServiceTypeRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(SiteServiceType model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fsiteservicetype_set", new Dictionary<string, object>
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

		public void Update(SiteServiceType model)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<SiteServiceType> GetAll()
		{
			throw new NotImplementedException();
		}

		public SiteServiceType GetById<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ServiceType> GetBySite<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<ServiceType>>(@"rtsurvey.fsiteservicetypebyidsite_get", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
			});
		}

		public void DeleteBySite<TId>(TId id)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fsiteservicetypebyidsite_delete", new Dictionary<string, object>
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