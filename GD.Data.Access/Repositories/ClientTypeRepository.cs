using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class ClientTypeRepository : IRepository<ClientType>
	{
		private IDataAccessContext DbContext { get; }

		public ClientTypeRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(ClientType model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fclienttype_set", new Dictionary<string, object>
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

		public void Update(ClientType model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fclienttype_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<ClientType> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<ClientType>>(@"rtsurvey.fclienttype_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public ClientType GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<ClientType>>(@"rtsurvey.fclienttype_get", new Dictionary<string, object>
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