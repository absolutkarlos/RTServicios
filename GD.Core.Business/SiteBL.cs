using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Core.Business
{
	public class SiteBl : ISiteBl
	{
		private ISiteRepository Repository { get; }
		private ISiteServiceTypeRepository SiteServiceTypeRepository { get; }

		public SiteBl(ISiteRepository repository, ISiteServiceTypeRepository siteServiceTypeRepository)
		{
			Repository = repository;
			SiteServiceTypeRepository = siteServiceTypeRepository;
		}

		public long InsertValue(Site model)
		{
			if (!model.IsNullOrEmpty())
			{
				var idSite = Repository.Insert(model);
				foreach (var serviceType in model.ListServiceType)
				{
					SiteServiceTypeRepository.Insert(new SiteServiceType
					{
						ServiceType = new ServiceType
						{
							Id = serviceType.Id
						},
						Site = new Site
						{
							Id = (int)idSite
						}
					});
				}
				return idSite;
			}
			return 0;
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(Site model)
		{
			Repository.Update(model);
		}

		public IEnumerable<Site> GetAllValues()
		{
			return Repository.GetAll();
		}

		public Site GetValueById<TId>(TId id)
		{
			return Repository.GetById(id);
		}

		public IEnumerable<Site> GetByClient<TId>(TId id)
		{
			return Repository.GetByClient(id);
		}

		public void UpdateBuildingInformation(Site site)
		{
			Repository.UpdateBuildingInformation(site);
		}

		public void UpdateLinkType(Site site)
		{
			Repository.UpdateLinkType(site);
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