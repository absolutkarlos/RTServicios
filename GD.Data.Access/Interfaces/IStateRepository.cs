using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Data.Access.Interfaces
{
	public interface IStateRepository : IRepository<State>
	{
		IEnumerable<State> GetByCountry<TId>(TId id);
	}
}