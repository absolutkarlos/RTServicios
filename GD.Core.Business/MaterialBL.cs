using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class MaterialBl : IBusinessLayer<Material>
	{
		private IRepository<Material> Repository { get; }

		public MaterialBl(IRepository<Material> repository)
		{
			Repository = repository;
		}

		public long InsertValue(Material model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(Material model)
		{
			Repository.Update(model);
		}

		public IEnumerable<Material> GetAllValues()
		{
			return Repository.GetAll();
		}

		public Material GetValueById<TId>(TId id)
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