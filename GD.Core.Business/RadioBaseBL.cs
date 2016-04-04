using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class RadioBaseBl : IBusinessLayer<RadioBase>
	{
		private IRepository<RadioBase> Repository { get; }

		public RadioBaseBl(IRepository<RadioBase> repository)
		{
			Repository = repository;
		}

		public long InsertValue(RadioBase model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(RadioBase model)
		{
			Repository.Update(model);
		}

		public IEnumerable<RadioBase> GetAllValues()
		{
			return Repository.GetAll();
		}

		public RadioBase GetValueById<TId>(TId id)
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