using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class OrderShotBl : IOrderShotBl
	{
		private IOrderShotRepository Repository { get; }

		public OrderShotBl(IOrderShotRepository repository)
		{
			Repository = repository;
		}

		public long InsertValue(OrderShot model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(OrderShot model)
		{
			Repository.Update(model);
		}

		public IEnumerable<OrderShot> GetAllValues()
		{
			return Repository.GetAll();
		}

		public OrderShot GetValueById<TId>(TId id)
		{
			return Repository.GetById(id);
		}

		public IEnumerable<OrderShot> GetByOrder<TId>(TId id)
		{
			return Repository.GetByOrder(id);
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