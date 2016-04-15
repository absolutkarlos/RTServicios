using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Data.Access.Interfaces
{
	public interface IOrderRepository : IRepository<Order>
	{
		IEnumerable<Order> GetByUser<TId>(TId id);
		Order GetInfo<TId>(TId id);
		void UpdateOrderInformation(Order model);
		void UpdateOrderSettingUp(Order model);
	}
}