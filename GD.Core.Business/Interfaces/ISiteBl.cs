using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Core.Business.Interfaces
{
	public interface ISiteBl : IBusinessLayer<Site>
	{
		IEnumerable<Site> GetByClient<TId>(TId id);
		void UpdateBuildingInformation(Site site);
		void UpdateLinkType(Site site);
	}
}