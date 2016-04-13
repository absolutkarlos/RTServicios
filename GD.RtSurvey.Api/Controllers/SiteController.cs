using System;
using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;
using GD.RtSurvey.Api.Controllers.Base;
using Newtonsoft.Json;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	[RoutePrefix(@"api/site")]
	public class SiteController : BaseController
	{
		private readonly ISiteBl _siteBl;

		public SiteController(ISiteBl siteBl)
		{
			_siteBl = siteBl;
		}

		// GET api/Site
		public IEnumerable<Site> Get()
		{
			return _siteBl.GetAllValues();
		}

		// GET api/Site/5
		public Site Get(int id)
		{
			return _siteBl.GetValueById(id);
		}

		// POST api/Site
		public long Post([FromBody]Site site)
		{
			return _siteBl.InsertValue(site);
		}

		// PUT api/Site
		public void Put([FromBody]Site site)
		{
			_siteBl.UpdateValue(site);
		}

		// DELETE api/Site/5
		public void Delete(int id)
		{
			_siteBl.DeleteValue(id);
		}

		// GET api/Site/GetByClient/5
		[Route(@"GetByClient/{id}")]
		public IEnumerable<Site> GetByClient(int id)
		{
			return _siteBl.GetByClient(id);
		}

		// PUT api/Site/BuildingInformation/
		[HttpPut]
		[Route(@"UpdateBuildingInformation/")]
		public void UpdateBuildingInformation([FromBody]Site site)
		{
			_siteBl.UpdateBuildingInformation(site);
		}

		// PUT api/Site/UpdateLinkType/
		[HttpPut]
		[Route(@"UpdateLinkType/")]
		public void UpdateLinkType([FromBody]Site site)
		{
			_siteBl.UpdateLinkType(site);
		}
	}
}