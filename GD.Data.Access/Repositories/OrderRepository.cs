using System;
using System.Collections.Generic;
using System.Linq;
using GD.Models.Commons;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons.Utilities;

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
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.forder_set", new Dictionary<string, object>
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

		public void Update(Order model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.forder_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<Order> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<Order>>(@"rtsurvey.forder_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public Order GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Order>>(@"rtsurvey.forder_get", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
			}).FirstOrDefault();
		}

		public IEnumerable<Order> GetByUser<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Order>>(@"rtsurvey.forderbyiduser_get", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
			});
		}

		public Order GetInfo<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Order>>(@"rtsurvey.forderbyidorder_get", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
			}).FirstOrDefault();
		}

		public void UpdateOrderInformation(Order model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.forderbyidorder_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public void UpdateOrderSettingUp(Order model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.forderbyidorder2_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
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