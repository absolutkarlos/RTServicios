using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class EntityChannelTypeBl : IBusinessLayer<EntityChannelType>
	{
		private IRepository<EntityChannelType> Repository { get; }

		public EntityChannelTypeBl(IRepository<EntityChannelType> repository)
		{
			Repository = repository;
		}

		public long InsertValue(EntityChannelType model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(EntityChannelType model)
		{
			Repository.Update(model);
		}

		public IEnumerable<EntityChannelType> GetAllValues()
		{
			return Repository.GetAll();
		}

		public EntityChannelType GetValueById<TId>(TId id)
		{
			return Repository.GetById(id);
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