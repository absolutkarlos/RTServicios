using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Data.Access.Interfaces
{
	public interface ISiteServiceTypeRepository : IRepository<SiteServiceType>
	{
		IEnumerable<ServiceType> GetBySite<TId>(TId id);
		void DeleteBySite<TId>(TId id);
	}
}