using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class UnitMeasureBl : IBusinessLayer<UnitMeasure>
	{
		private IRepository<UnitMeasure> Repository { get; }

		public UnitMeasureBl(IRepository<UnitMeasure> repository)
		{
			Repository = repository;
		}

		public long InsertValue(UnitMeasure model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(UnitMeasure model)
		{
			Repository.Update(model);
		}

		public IEnumerable<UnitMeasure> GetAllValues()
		{
			return Repository.GetAll();
		}

		public UnitMeasure GetValueById<TId>(TId id)
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