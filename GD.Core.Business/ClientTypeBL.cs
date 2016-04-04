using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class ClientTypeBl : IBusinessLayer<ClientType>
	{
		private IRepository<ClientType> Repository { get; }

		public ClientTypeBl(IRepository<ClientType> repository)
		{
			Repository = repository;
		}

		public long InsertValue(ClientType model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(ClientType model)
		{
			Repository.Update(model);
		}

		public IEnumerable<ClientType> GetAllValues()
		{
			return Repository.GetAll();
		}

		public ClientType GetValueById<TId>(TId id)
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