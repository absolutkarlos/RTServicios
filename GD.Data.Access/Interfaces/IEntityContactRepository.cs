using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Data.Access.Interfaces
{
	public interface IEntityContactRepository: IRepository<EntityContact>
	{
		IEnumerable<EntityContact> GetByClient<TId>(TId id);
	}
}