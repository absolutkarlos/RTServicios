using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Data.Access.Interfaces
{
	public interface ICityRepository : IRepository<City>
	{
		IEnumerable<City> GetByState<TId>(TId id);
	}
}