using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class LineSightBl : IBusinessLayer<LineSight>
	{
		private IRepository<LineSight> Repository { get; }

		public LineSightBl(IRepository<LineSight> repository)
		{
			Repository = repository;
		}

		public long InsertValue(LineSight model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(LineSight model)
		{
			Repository.Update(model);
		}

		public IEnumerable<LineSight> GetAllValues()
		{
			return Repository.GetAll();
		}

		public LineSight GetValueById<TId>(TId id)
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