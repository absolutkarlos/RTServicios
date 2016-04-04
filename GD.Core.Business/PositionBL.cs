using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class PositionBl : IBusinessLayer<Position>
	{
		private IRepository<Position> Repository { get; }

		public PositionBl(IRepository<Position> repository)
		{
			Repository = repository;
		}

		public long InsertValue(Position model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(Position model)
		{
			Repository.Update(model);
		}

		public IEnumerable<Position> GetAllValues()
		{
			return Repository.GetAll();
		}

		public Position GetValueById<TId>(TId id)
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