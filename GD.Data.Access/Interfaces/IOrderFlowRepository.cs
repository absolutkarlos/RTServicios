using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Data.Access.Interfaces
{
	public interface IOrderFlowRepository : IRepository<OrderFlow>
	{
		void UpdateStatus(OrderFlow model);
		IEnumerable<OrderFlow> GetByOrder<TId>(TId id);
	}
}