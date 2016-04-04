using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class EntityChannelBl : IEntityChannelBl
	{
		private IEntityChannelRepository Repository { get; }

		public EntityChannelBl(IEntityChannelRepository repository)
		{
			Repository = repository;
		}

		public long InsertValue(EntityChannel model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(EntityChannel model)
		{
			Repository.Update(model);
		}

		public IEnumerable<EntityChannel> GetAllValues()
		{
			return Repository.GetAll();
		}

		public EntityChannel GetValueById<TId>(TId id)
		{
			return Repository.GetById(id);
		}

		public IEnumerable<EntityChannel> GetByEntity<TId>(TId id)
		{
			return Repository.GetByEntity(id);
		}

		public void InsertList(List<EntityChannel> entityChannels)
		{
			foreach (var entityChannel in entityChannels)
			{
				Repository.Insert(entityChannel);
			}
		}

		public bool ExistsValue<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}