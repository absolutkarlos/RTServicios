using System;
using System.Collections.Generic;
using System.Linq;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class SiteScheduleBl : ISiteScheduleBl
	{
		private ISiteSheduleRepository Repository { get; }

		public SiteScheduleBl(ISiteSheduleRepository repository)
		{
			Repository = repository;
		}

		public long InsertValue(SiteSchedule model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(SiteSchedule model)
		{
			Repository.Update(model);
		}

		public IEnumerable<SiteSchedule> GetAllValues()
		{
			return Repository.GetAll();
		}

		public SiteSchedule GetValueById<TId>(TId id)
		{
			return Repository.GetById(id);
		}

		public IEnumerable<SiteSchedule> GetBySite<TId>(TId id)
		{
			return Repository.GetBySite(id);
		}

		public void InsertList(List<SiteSchedule> siteSchedules)
		{
			if (siteSchedules.Any())
			{
				Repository.DeleteBySite(siteSchedules.ElementAt(0).Site.Id);
				foreach (var siteSchedule in siteSchedules)
				{
					Repository.Insert(siteSchedule);
				}
			}
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