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
	public class OrderStatusRepository : IRepository<OrderStatus>
	{
		private IDataAccessContext DbContext { get; }

		public OrderStatusRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(OrderStatus model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.forderstatus_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(OrderStatus model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.forderstatus_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<OrderStatus> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<OrderStatus>>(@"rtsurvey.forderstatus_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public OrderStatus GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<OrderStatus>>(@"rtsurvey.forderstatus_get", new List<Parameter>
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