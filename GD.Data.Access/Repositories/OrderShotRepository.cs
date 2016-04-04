using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

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
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fordershot_set", new Dictionary<string, object>
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

		public void Update(OrderShot model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fordershot_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<OrderShot> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<OrderShot>>(@"rtsurvey.fordershot_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public OrderShot GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<OrderShot>>(@"rtsurvey.fordershot_get", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
			}).FirstOrDefault();
		}

		public IEnumerable<OrderShot> GetByOrder<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<OrderShot>>(@"rtsurvey.fordershotbyidorder_get", new Dictionary<string, object>
			{
				{
					@"_id", id
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