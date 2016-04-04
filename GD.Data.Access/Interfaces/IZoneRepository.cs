using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Data.Access.Interfaces
{
	public interface IZoneRepository : IRepository<Zone>
	{
		IEnumerable<Zone> GetByCity<TId>(TId id);
	}
}