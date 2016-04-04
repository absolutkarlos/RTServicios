using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Data.Access.Interfaces
{
	public interface IOrderMaterialRepository : IRepository<OrderMaterial>
	{
		void DeleteByOrder<TId>(TId id);
		IEnumerable<OrderMaterial> GetByOrder<TId>(TId id);
	}
}