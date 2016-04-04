using System;
using System.Collections.Generic;
using System.Linq;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class EntityContactBl : IEntityContactBl
	{
		private IEntityContactRepository Repository { get; }
		private IEntityChannelRepository EntityChannelRepository { get; }

		public EntityContactBl(IEntityContactRepository repository, IEntityChannelRepository entityChannelRepository)
		{
			Repository = repository;
			EntityChannelRepository = entityChannelRepository;
		}

		public long InsertValue(EntityContact model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(EntityContact model)
		{
			Repository.Update(model);
		}

		public IEnumerable<EntityContact> GetAllValues()
		{
			return Repository.GetAll();
		}

		public EntityContact GetValueById<TId>(TId id)
		{
			return Repository.GetById(id);
		}

		public IEnumerable<EntityContact> GetByClient<TId>(TId id)
		{
			var contactList = Repository.GetByClient(id).ToList();
			foreach (var item in contactList)
			{
				var list = EntityChannelRepository.GetByEntity(item.Id).ToList();
				if (list.Any())
				{
					var entityChannels = new List<EntityChannel>();
					entityChannels.AddRange(list);
					item.ListEntityChannels = entityChannels;
				}
			}
			return contactList;
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