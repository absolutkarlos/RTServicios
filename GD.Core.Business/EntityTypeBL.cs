using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class EntityTypeBl : IBusinessLayer<EntityType>
	{
		private IRepository<EntityType> Repository { get; }

		public EntityTypeBl(IRepository<EntityType> repository)
		{
			Repository = repository;
		}

		public long InsertValue(EntityType model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(EntityType model)
		{
			Repository.Update(model);
		}

		public IEnumerable<EntityType> GetAllValues()
		{
			return Repository.GetAll();
		}

		public EntityType GetValueById<TId>(TId id)
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