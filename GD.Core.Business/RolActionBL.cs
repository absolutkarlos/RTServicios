using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class RolActionBl : IBusinessLayer<RolAction>
	{
		private IRepository<RolAction> Repository { get; }

		public RolActionBl(IRepository<RolAction> repository)
		{
			Repository = repository;
		}

		public long InsertValue(RolAction model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(RolAction model)
		{
			Repository.Update(model);
		}

		public IEnumerable<RolAction> GetAllValues()
		{
			return Repository.GetAll();
		}

		public RolAction GetValueById<TId>(TId id)
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