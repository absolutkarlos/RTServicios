using System;
using System.Collections.Generic;
using System.Linq;
using GD.Models.Commons;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons.Utilities;
using NpgsqlTypes;

namespace GD.Data.Access.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private IDataAccessContext DbContext { get; }

		public OrderRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(Order model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.forder_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(Order model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.forder_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<Order> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<Order>>(@"rtsurvey.forder_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public Order GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Order>>(@"rtsurvey.forder_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = id }
			}).FirstOrDefault();
		}

		public IEnumerable<Order> GetByUser<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Order>>(@"rtsurvey.forderbyiduser_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = id }
			});
		}

		public Order GetInfo<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Order>>(@"rtsurvey.forderbyidorder_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = id }
			}).FirstOrDefault();
		}

		public void UpdateOrderInformation(Order model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.forderbyidorder_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void UpdateOrderSettingUp(Order model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.forderbyidorder2_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
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