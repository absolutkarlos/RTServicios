using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class StatusBl : IBusinessLayer<Status>
	{
		private IRepository<Status> Repository { get; }

		public StatusBl(IRepository<Status> repository)
		{
			Repository = repository;
		}

		public long InsertValue(Status model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(Status model)
		{
			Repository.Update(model);
		}

		public IEnumerable<Status> GetAllValues()
		{
			return Repository.GetAll();
		}

		public Status GetValueById<TId>(TId id)
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