using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Core.Business.Interfaces
{
	public interface IStateBl : IBusinessLayer<State>
	{
		IEnumerable<State> GetByCountry<TId>(TId id);
	}
}