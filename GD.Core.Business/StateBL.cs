using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class StateBl : IStateBl
	{
		private IStateRepository Repository { get; }

		public StateBl(IStateRepository repository)
		{
			Repository = repository;
		}

		public long InsertValue(State model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(State model)
		{
			Repository.Update(model);
		}

		public IEnumerable<State> GetAllValues()
		{
			return Repository.GetAll();
		}

		public State GetValueById<TId>(TId id)
		{
			return Repository.GetById(id);
		}

		public IEnumerable<State> GetByCountry<TId>(TId id)
		{
			return Repository.GetByCountry(id);
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