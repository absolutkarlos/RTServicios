using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Data.Access.Interfaces
{
	public interface ISiteSheduleRepository : IRepository<SiteSchedule>
	{
		IEnumerable<SiteSchedule> GetBySite<TId>(TId id);
		void DeleteBySite<TId>(TId id);
	}
}