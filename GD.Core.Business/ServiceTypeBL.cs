using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class ServiceTypeBl : IBusinessLayer<ServiceType>
	{
		private IRepository<ServiceType> Repository { get; }

		public ServiceTypeBl(IRepository<ServiceType> repository)
		{
			Repository = repository;
		}

		public long InsertValue(ServiceType model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(ServiceType model)
		{
			Repository.Update(model);
		}

		public IEnumerable<ServiceType> GetAllValues()
		{
			return Repository.GetAll();
		}

		public ServiceType GetValueById<TId>(TId id)
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