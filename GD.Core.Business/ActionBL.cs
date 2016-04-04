using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using Action = GD.Models.Commons.Action;

namespace GD.Core.Business
{
	public class ActionBl : IBusinessLayer<Action>
	{
		private IRepository<Action> Repository { get; }

		public ActionBl(IRepository<Action> repository)
		{
			Repository = repository;
		}

		public long InsertValue(Action model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(Action model)
		{
			Repository.Update(model);
		}

		public IEnumerable<Action> GetAllValues()
		{
			return Repository.GetAll();
		}

		public Action GetValueById<TId>(TId id)
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