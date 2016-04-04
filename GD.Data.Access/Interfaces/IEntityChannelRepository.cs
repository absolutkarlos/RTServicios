using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Data.Access.Interfaces
{
	public interface IEntityChannelRepository : IRepository<EntityChannel>
	{
		/// <summary>
		/// Get list entity channel by id entity
		/// </summary>
		/// <param name="id">The id of entity</param>
		IEnumerable<EntityChannel> GetByEntity<TId>(TId id);
	}
}