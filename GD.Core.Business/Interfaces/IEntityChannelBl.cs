using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Core.Business.Interfaces
{
	public interface IEntityChannelBl : IBusinessLayer<EntityChannel>
	{
		/// <summary>
		/// Get list entity channel by id entity
		/// </summary>
		/// <param name="id">The id of entity</param>
		IEnumerable<EntityChannel> GetByEntity<TId>(TId id);

		/// <summary>
		/// Insert list entity channel
		/// </summary>
		/// <param name="entityChannels">List of entity Channel</param>
		void InsertList(List<EntityChannel> entityChannels);
	}
}