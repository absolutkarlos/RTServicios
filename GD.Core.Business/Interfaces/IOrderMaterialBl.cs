using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Core.Business.Interfaces
{
	public interface IOrderMaterialBl : IBusinessLayer<OrderMaterial>
	{
		void DeleteByOrder<TId>(TId id);
		IEnumerable<OrderMaterial> GetByOrder<TId>(TId id);
		void InsertList(List<OrderMaterial> orderMaterials);
	}
}