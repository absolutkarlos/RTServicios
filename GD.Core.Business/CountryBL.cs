using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class CountryBl : IBusinessLayer<Country>
	{
		private IRepository<Country> Repository { get; }

		public CountryBl(IRepository<Country> repository)
		{
			Repository = repository;
		}

		public long InsertValue(Country model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(Country model)
		{
			Repository.Update(model);
		}

		public IEnumerable<Country> GetAllValues()
		{
			return Repository.GetAll();
		}

		public Country GetValueById<TId>(TId id)
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