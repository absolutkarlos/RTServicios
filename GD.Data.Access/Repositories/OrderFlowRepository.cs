using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class OrderFlowRepository : IOrderFlowRepository
	{
		private IDataAccessContext DbContext { get; }

		public OrderFlowRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(OrderFlow model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.forderflow_set", new Dictionary<string, object>
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

		public void Update(OrderFlow model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.forderflow_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<OrderFlow> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<OrderFlow>>(@"rtsurvey.forderflow_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public OrderFlow GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<OrderFlow>>(@"rtsurvey.forderflow_get", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
			}).FirstOrDefault();
		}

		public void UpdateStatus(OrderFlow model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.forderflow_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<OrderFlow> GetByOrder<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<OrderFlow>>(@"rtsurvey.forderflowbyidorder_get", new Dictionary<string, object>
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