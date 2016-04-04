using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class OrderStatusBl : IBusinessLayer<OrderStatus>
	{
		private IRepository<OrderStatus> Repository { get; }

		public OrderStatusBl(IRepository<OrderStatus> repository)
		{
			Repository = repository;
		}

		public long InsertValue(OrderStatus model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(OrderStatus model)
		{
			Repository.Update(model);
		}

		public IEnumerable<OrderStatus> GetAllValues()
		{
			return Repository.GetAll();
		}

		public OrderStatus GetValueById<TId>(TId id)
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
	}
}