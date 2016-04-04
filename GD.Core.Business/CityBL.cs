using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class CityBl : ICityBl
	{
		private ICityRepository Repository { get; }

		public CityBl(ICityRepository repository)
		{
			Repository = repository;
		}

		public long InsertValue(City model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(City model)
		{
			Repository.Update(model);
		}

		public IEnumerable<City> GetAllValues()
		{
			return Repository.GetAll();
		}

		public City GetValueById<TId>(TId id)
		{
			return Repository.GetById(id);
		}

		public IEnumerable<City> GetByState<TId>(TId id)
		{
			return Repository.GetByState(id);
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