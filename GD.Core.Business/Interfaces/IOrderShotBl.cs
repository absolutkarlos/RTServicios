using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Core.Business.Interfaces
{
	public interface IOrderShotBl : IBusinessLayer<OrderShot>
	{
		IEnumerable<OrderShot> GetByOrder<TId>(TId id);
	}
}