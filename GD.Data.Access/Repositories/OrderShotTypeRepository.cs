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
	public class OrderShotTypeRepository : IRepository<OrderShotType>
	{
		private IDataAccessContext DbContext { get; }

		public OrderShotTypeRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(OrderShotType model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fordershottype_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(OrderShotType model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fordershottype_update", new List <Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<OrderShotType> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<OrderShotType>>(@"rtsurvey.fordershottype_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public OrderShotType GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<OrderShotType>>(@"rtsurvey.fordershottype_get", new List<Parameter>
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