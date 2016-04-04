using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	[RoutePrefix(@"api/siteschedule")]
	public class SiteScheduleController : BaseController
	{
		private readonly ISiteScheduleBl _siteScheduleBl;

		public SiteScheduleController(ISiteScheduleBl siteScheduleBl)
		{
			_siteScheduleBl = siteScheduleBl;
		}

		// GET api/SiteSchedule
		public IEnumerable<SiteSchedule> Get()
		{
			return _siteScheduleBl.GetAllValues();
		}

		// GET api/SiteSchedule/5
		public SiteSchedule Get(int id)
		{
			return _siteScheduleBl.GetValueById(id);
		}

		// POST api/SiteSchedule
		public long Post([FromBody]SiteSchedule siteSchedule)
		{
			return _siteScheduleBl.InsertValue(siteSchedule);
		}

		// PUT api/SiteSchedule
		public void Put([FromBody]SiteSchedule siteSchedule)
		{
			_siteScheduleBl.UpdateValue(siteSchedule);
		}

		// DELETE api/SiteSchedule/5
		public void Delete(int id)
		{
			_siteScheduleBl.DeleteValue(id);
		}

		// GET api/SiteSchedule/GetByClient/5
		[Route(@"GetBySite/{id}")]
		public IEnumerable<SiteSchedule> GetBySite(int id)
		{
			return _siteScheduleBl.GetBySite(id);
		}

		// POST api/SiteSchedule
		[HttpPost]
		[Route(@"InsertList/")]
		public void InsertList([FromBody]List<SiteSchedule> siteSchedules)
		{
			_siteScheduleBl.InsertList(siteSchedules);
		}
	}
}