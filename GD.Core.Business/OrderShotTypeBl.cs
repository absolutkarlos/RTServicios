using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class OrderShotTypeBl : IBusinessLayer<OrderShotType>
	{
		private IRepository<OrderShotType> Repository { get; }

		public OrderShotTypeBl(IRepository<OrderShotType> repository)
		{
			Repository = repository;
		}

		public long InsertValue(OrderShotType model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(OrderShotType model)
		{
			Repository.Update(model);
		}

		public IEnumerable<OrderShotType> GetAllValues()
		{
			return Repository.GetAll();
		}

		public OrderShotType GetValueById<TId>(TId id)
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