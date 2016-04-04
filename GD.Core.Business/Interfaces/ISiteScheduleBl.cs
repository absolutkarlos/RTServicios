using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Core.Business.Interfaces
{
	public interface ISiteScheduleBl : IBusinessLayer<SiteSchedule>
	{
		IEnumerable<SiteSchedule> GetBySite<TId>(TId id);
		void InsertList(List<SiteSchedule> siteSchedules);
	}
}