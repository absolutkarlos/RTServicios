using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Core.Business.Interfaces
{
	public interface IEntityContactBl : IBusinessLayer<EntityContact>
	{
		IEnumerable<EntityContact> GetByClient<TId>(TId id);
	}
}