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
	public class OrderShotRepository : IOrderShotRepository
	{
		private IDataAccessContext DbContext { get; }

		public OrderShotRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(OrderShot model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fordershot_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(OrderShot model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fordershot_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<OrderShot> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<OrderShot>>(@"rtsurvey.fordershot_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public OrderShot GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<OrderShot>>(@"rtsurvey.fordershot_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = id }
			}).FirstOrDefault();
		}

		public IEnumerable<OrderShot> GetByOrder<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<OrderShot>>(@"rtsurvey.fordershotbyidorder_get", new List<Parameter>
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