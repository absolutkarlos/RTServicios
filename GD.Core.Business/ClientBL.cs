using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class ClientBl : IClientBl
	{
		private IClientRepository Repository { get; }

		public ClientBl(IClientRepository repository)
		{
			Repository = repository;
		}

		public long InsertValue(Client model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(Client model)
		{
			Repository.Update(model);
		}

		public IEnumerable<Client> GetAllValues()
		{
			return Repository.GetAll();
		}

		public Client GetValueById<TId>(TId id)
		{
			return Repository.GetById(id);
		}

		public Client GetInfo<TId>(TId id)
		{
			return Repository.GetInfo(id);
		}

		public int ValidateByRuc(string ruc)
		{
			return Repository.ValidateByRuc(ruc);
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