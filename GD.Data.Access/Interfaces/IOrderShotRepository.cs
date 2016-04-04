using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Data.Access.Interfaces
{
	public interface IOrderShotRepository : IRepository<OrderShot>
	{
		IEnumerable<OrderShot> GetByOrder<TId>(TId id);
	}
}