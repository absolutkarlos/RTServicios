using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	[RoutePrefix(@"api/siteaccesstype")]
	public class SiteAccessTypeController : BaseController
	{
		private readonly ISiteAccessTypeBl _siteAccessTypeBl;

		public SiteAccessTypeController(ISiteAccessTypeBl siteAccessTypeBl)
		{
			_siteAccessTypeBl = siteAccessTypeBl;
		}

		// GET api/SiteAccessType
		public IEnumerable<SiteAccessType> Get()
		{
			return _siteAccessTypeBl.GetAllValues();
		}

		// GET api/SiteAccessType/5
		public SiteAccessType Get(int id)
		{
			return _siteAccessTypeBl.GetValueById(id);
		}

		// POST api/SiteAccessType
		public long Post([FromBody]SiteAccessType siteAccessType)
		{
			return _siteAccessTypeBl.InsertValue(siteAccessType);
		}

		// PUT api/SiteAccessType
		public void Put([FromBody]SiteAccessType siteAccessType)
		{
			_siteAccessTypeBl.UpdateValue(siteAccessType);
		}

		// DELETE api/SiteAccessType/5
		public void Delete(int id)
		{
			_siteAccessTypeBl.DeleteValue(id);
		}

		// DELETE api/SiteAccessType/DeleteBySite/5
		public void DeleteBySite(int id)
		{
			_siteAccessTypeBl.DeleteBySite(id);
		}

		// GET api/SiteAccessType/GetBySite/5
		[Route(@"GetBySite/{id}")]
		public IEnumerable<SiteAccessType> GetBySite(int id)
		{
			return _siteAccessTypeBl.GetBySite(id);
		}

		// POST api/SiteAccessType
		[HttpPost]
		[Route(@"InsertList/")]
		public void InsertList([FromBody]List<SiteAccessType> siteSchedules)
		{
			_siteAccessTypeBl.InsertList(siteSchedules);
		}
	}
}