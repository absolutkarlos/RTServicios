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
	public class OrderMaterialRepository : IOrderMaterialRepository
	{
		private IDataAccessContext DbContext { get; }

		public OrderMaterialRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(OrderMaterial model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fordermaterial_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(OrderMaterial model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fordermaterial_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<OrderMaterial> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<OrderMaterial>>(@"rtsurvey.fordermaterial_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public OrderMaterial GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<OrderMaterial>>(@"rtsurvey.fordermaterial_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = id }
			}).FirstOrDefault();
		}

		public void DeleteByOrder<TId>(TId id)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fordermaterialbyidorder_delete", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = id }
			});
		}

		public IEnumerable<OrderMaterial> GetByOrder<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<OrderMaterial>>(@"rtsurvey.fordermaterialbyidorder_get", new List<Parameter>
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