using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class OrderFlowBl : IOrderFlowBl
	{
		private IOrderFlowRepository Repository { get; }

		public OrderFlowBl(IOrderFlowRepository repository)
		{
			Repository = repository;
		}

		public long InsertValue(OrderFlow model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(OrderFlow model)
		{
			Repository.Update(model);
		}

		public IEnumerable<OrderFlow> GetAllValues()
		{
			return Repository.GetAll();
		}

		public OrderFlow GetValueById<TId>(TId id)
		{
			return Repository.GetById(id);
		}

		public bool ExistsValue<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public void UpdateStatus(OrderFlow orderFlow)
		{
			Repository.UpdateStatus(orderFlow);
		}
	}
}