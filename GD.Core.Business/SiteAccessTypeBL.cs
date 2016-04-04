using System;
using System.Collections.Generic;
using System.Linq;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class SiteAccessTypeBl : ISiteAccessTypeBl
	{
		private ISiteAccessTypeRepository Repository { get; }

		public SiteAccessTypeBl(ISiteAccessTypeRepository repository)
		{
			Repository = repository;
		}

		public long InsertValue(SiteAccessType model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(SiteAccessType model)
		{
			Repository.Update(model);
		}

		public IEnumerable<SiteAccessType> GetAllValues()
		{
			return Repository.GetAll();
		}

		public SiteAccessType GetValueById<TId>(TId id)
		{
			return Repository.GetById(id);
		}

		public IEnumerable<SiteAccessType> GetBySite<TId>(TId id)
		{
			return Repository.GetBySite(id);
		}

		public void InsertList(List<SiteAccessType> siteAccessTypes)
		{
			if (siteAccessTypes.Any())
			{
				Repository.DeleteBySite(siteAccessTypes.ElementAt(0).Site.Id);
				foreach (var siteAccessType in siteAccessTypes)
				{
					Repository.Insert(siteAccessType);
				}
			}
		}

		public void DeleteBySite<TId>(TId id)
		{
			Repository.DeleteBySite(id);
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