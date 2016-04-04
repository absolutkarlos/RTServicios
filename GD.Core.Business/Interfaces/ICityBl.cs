using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Core.Business.Interfaces
{
	public interface ICityBl : IBusinessLayer<City>
	{
		IEnumerable<City> GetByState<TId>(TId id);
	}
}