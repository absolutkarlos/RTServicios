using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Core.Business.Interfaces
{
	public interface IOrderBl : IBusinessLayer<Order>
	{
		IEnumerable<Order> GetByUser<TId>(TId id);
		Order GetInfo<TId>(TId id);
		long UpdateStatus(Order model);
		void UpdateOrderInformation(Order order);
		void UpdateOrderSettingUp(Order order);
	}
}