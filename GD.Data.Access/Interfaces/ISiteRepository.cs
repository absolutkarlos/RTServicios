using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Data.Access.Interfaces
{
	public interface ISiteRepository : IRepository<Site>
	{
		IEnumerable<Site> GetByClient<TId>(TId id);
		void UpdateBuildingInformation(Site site);
	}
}