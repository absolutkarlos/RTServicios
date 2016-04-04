using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class RolBl : IBusinessLayer<Rol>
	{
		private IRepository<Rol> Repository { get; }

		public RolBl(IRepository<Rol> repository)
		{
			Repository = repository;
		}

		public long InsertValue(Rol model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(Rol model)
		{
			Repository.Update(model);
		}

		public IEnumerable<Rol> GetAllValues()
		{
			return Repository.GetAll();
		}

		public Rol GetValueById<TId>(TId id)
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