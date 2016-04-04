using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Core.Business.Interfaces
{
	public interface ISiteAccessTypeBl : IBusinessLayer<SiteAccessType>
	{
		IEnumerable<SiteAccessType> GetBySite<TId>(TId id);
		void DeleteBySite<TId>(TId id);
		void InsertList(List<SiteAccessType> siteAccessTypes);
	}
}