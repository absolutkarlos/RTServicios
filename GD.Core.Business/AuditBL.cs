using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class AuditBl : IBusinessLayer<Audit>
	{
		private IRepository<Audit> Repository { get; }

		public AuditBl(IRepository<Audit> repository)
		{
			Repository = repository;
		}

		public long InsertValue(Audit model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(Audit model)
		{
			Repository.Update(model);
		}

		public IEnumerable<Audit> GetAllValues()
		{
			return Repository.GetAll();
		}

		public Audit GetValueById<TId>(TId id)
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