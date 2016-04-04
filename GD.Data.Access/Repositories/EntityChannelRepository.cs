using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class EntityChannelRepository : IEntityChannelRepository
	{
		private IDataAccessContext DbContext { get; }

		public EntityChannelRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(EntityChannel model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fentitychannel_set", new Dictionary<string, object>
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

		public void Update(EntityChannel model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fentitychannel_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<EntityChannel> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<EntityChannel>>(@"rtsurvey.fentitychannel_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public EntityChannel GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<EntityChannel>>(@"rtsurvey.fentitychannel_get", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
			}).FirstOrDefault();
		}

		public IEnumerable<EntityChannel> GetByEntity<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<EntityChannel>>(@"rtsurvey.fentitychannelbyidentitycontact_get", new Dictionary<string, object>
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