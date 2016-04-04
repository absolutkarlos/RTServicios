using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class EntityTypeRepository : IRepository<EntityType>
	{
		private IDataAccessContext DbContext { get; }

		public EntityTypeRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(EntityType model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fentitytype_set", new Dictionary<string, object>
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

		public void Update(EntityType model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fentitytype_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<EntityType> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<EntityType>>(@"rtsurvey.fentitytype_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public EntityType GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<EntityType>>(@"rtsurvey.fentitytype_get", new Dictionary<string, object>
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