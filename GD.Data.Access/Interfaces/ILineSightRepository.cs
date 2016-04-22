using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Data.Access.Interfaces
{
	public interface ILineSightRepository : IRepository<LineSight>
	{
		IEnumerable<LineSight> GetBySite<TId>(TId id);
	}
}