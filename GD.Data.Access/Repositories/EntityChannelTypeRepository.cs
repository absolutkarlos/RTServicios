using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;
using NpgsqlTypes;

namespace GD.Data.Access.Repositories
{
	public class EntityChannelTypeRepository : IRepository<EntityChannelType>
	{
		private IDataAccessContext DbContext { get; }

		public EntityChannelTypeRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(EntityChannelType model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fentitychanneltype_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(EntityChannelType model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fentitychanneltype_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<EntityChannelType> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<EntityChannelType>>(@"rtsurvey.fentitychanneltype_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public EntityChannelType GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<EntityChannelType>>(@"rtsurvey.fentitychanneltype_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = id }
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