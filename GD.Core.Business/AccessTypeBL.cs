using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class AccessTypeBl : IBusinessLayer<AccessType>
	{
		private IRepository<AccessType> Repository { get; }

		public AccessTypeBl(IRepository<AccessType> repository)
		{
			Repository = repository;
		}

		public long InsertValue(AccessType model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(AccessType model)
		{
			Repository.Update(model);
		}

		public IEnumerable<AccessType> GetAllValues()
		{
			return Repository.GetAll();
		}

		public AccessType GetValueById<TId>(TId id)
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