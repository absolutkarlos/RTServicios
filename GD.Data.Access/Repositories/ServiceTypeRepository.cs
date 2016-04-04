using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

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
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fservicetype_set", new Dictionary<string, object>
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

		public void Update(ServiceType model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fservicetype_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<ServiceType> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<ServiceType>>(@"rtsurvey.fservicetype_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public ServiceType GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<ServiceType>>(@"rtsurvey.fservicetype_get", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
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