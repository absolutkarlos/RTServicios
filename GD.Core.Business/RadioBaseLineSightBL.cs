using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class RadioBaseLineSightBl : IBusinessLayer<RadioBaseLineSight>
	{
		private IRepository<RadioBaseLineSight> Repository { get; }

		public RadioBaseLineSightBl(IRepository<RadioBaseLineSight> repository)
		{
			Repository = repository;
		}

		public long InsertValue(RadioBaseLineSight model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(RadioBaseLineSight model)
		{
			Repository.Update(model);
		}

		public IEnumerable<RadioBaseLineSight> GetAllValues()
		{
			return Repository.GetAll();
		}

		public RadioBaseLineSight GetValueById<TId>(TId id)
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