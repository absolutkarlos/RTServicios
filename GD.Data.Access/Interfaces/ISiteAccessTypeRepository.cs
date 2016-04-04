using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Data.Access.Interfaces
{
	public interface ISiteAccessTypeRepository : IRepository<SiteAccessType>
	{
		IEnumerable<SiteAccessType> GetBySite<TId>(TId id);
		void DeleteBySite<TId>(TId id);
	}
}