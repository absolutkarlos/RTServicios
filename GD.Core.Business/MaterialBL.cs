using System;
using System.Collections.Generic;
using System.Linq;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class MaterialBl : IBusinessLayer<Material>
	{
		private IRepository<Material> Repository { get; }
		private IRepository<UnitMeasure> UnitMeasureRepository { get; }

		public MaterialBl(IRepository<Material> repository, IRepository<UnitMeasure> unitMeasureRepository)
		{
			Repository = repository;
			UnitMeasureRepository = unitMeasureRepository;
		}

		public long InsertValue(Material model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(Material model)
		{
			Repository.Update(model);
		}

		public IEnumerable<Material> GetAllValues()
		{
			var listMaterials = Repository.GetAll().ToList();

			if (listMaterials.Any())
			{
				foreach (var material in listMaterials)
				{
					material.UnitMeasure = UnitMeasureRepository.GetById(material.IdUnitMeasure);
				}
			}

			return listMaterials;
		}

		public Material GetValueById<TId>(TId id)
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