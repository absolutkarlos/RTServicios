using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Core.Business.Interfaces
{
	public interface IZoneBl : IBusinessLayer<Zone>
	{
		IEnumerable<Zone> GetByCity<TId>(TId id);
	}
}