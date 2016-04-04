using System;
using System.Collections.Generic;
using System.Linq;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class OrderMaterialBl : IOrderMaterialBl
	{
		private IOrderMaterialRepository Repository { get; }

		public OrderMaterialBl(IOrderMaterialRepository repository)
		{
			Repository = repository;
		}

		public long InsertValue(OrderMaterial model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(OrderMaterial model)
		{
			Repository.Update(model);
		}

		public IEnumerable<OrderMaterial> GetAllValues()
		{
			return Repository.GetAll();
		}

		public OrderMaterial GetValueById<TId>(TId id)
		{
			return Repository.GetById(id);
		}

		public void DeleteByOrder<TId>(TId id)
		{
			Repository.DeleteByOrder(id);
		}

		public IEnumerable<OrderMaterial> GetByOrder<TId>(TId id)
		{
			return Repository.GetByOrder(id);
		}

		public void InsertList(List<OrderMaterial> orderMaterials)
		{
			if (orderMaterials.Any())
			{
				Repository.DeleteByOrder(orderMaterials.ElementAt(0).Order.Id);
				foreach (var orderMaterial in orderMaterials)
				{
					Repository.Insert(orderMaterial);
				}
			}
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