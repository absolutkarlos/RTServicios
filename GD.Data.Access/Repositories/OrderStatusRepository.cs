using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

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
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.forderstatus_set", new Dictionary<string, object>
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

		public void Update(OrderStatus model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.forderstatus_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<OrderStatus> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<OrderStatus>>(@"rtsurvey.forderstatus_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public OrderStatus GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<OrderStatus>>(@"rtsurvey.forderstatus_get", new Dictionary<string, object>
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