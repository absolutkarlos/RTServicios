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
	public class EntityChannelRepository : IEntityChannelRepository
	{
		private IDataAccessContext DbContext { get; }

		public EntityChannelRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(EntityChannel model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fentitychannel_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(EntityChannel model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fentitychannel_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<EntityChannel> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<EntityChannel>>(@"rtsurvey.fentitychannel_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public EntityChannel GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<EntityChannel>>(@"rtsurvey.fentitychannel_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = id }
			}).FirstOrDefault();
		}

		public IEnumerable<EntityChannel> GetByEntity<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<EntityChannel>>(@"rtsurvey.fentitychannelbyidentitycontact_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = id }
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