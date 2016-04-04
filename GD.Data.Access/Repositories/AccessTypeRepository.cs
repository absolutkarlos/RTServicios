using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class AccessTypeRepository : IRepository<AccessType>
	{
		private IDataAccessContext DbContext { get; }

		public AccessTypeRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(AccessType model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.faccesstype_set", new Dictionary<string, object>
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

		public void Update(AccessType model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.faccesstype_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<AccessType> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<AccessType>>(@"rtsurvey.faccesstype_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			}); 
		}

		public AccessType GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<AccessType>>(@"rtsurvey.faccesstype_get", new Dictionary<string, object>
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