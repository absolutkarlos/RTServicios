using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class ZoneBl : IZoneBl
	{
		private IZoneRepository Repository { get; }

		public ZoneBl(IZoneRepository repository)
		{
			Repository = repository;
		}

		public long InsertValue(Zone model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(Zone model)
		{
			Repository.Update(model);
		}

		public IEnumerable<Zone> GetAllValues()
		{
			return Repository.GetAll();
		}

		public Zone GetValueById<TId>(TId id)
		{
			return Repository.GetById(id);
		}

		public IEnumerable<Zone> GetByCity<TId>(TId id)
		{
			return Repository.GetByCity(id);
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