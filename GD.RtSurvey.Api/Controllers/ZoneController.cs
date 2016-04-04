 using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.RtSurvey.Api.Controllers.Base;
using Zone = GD.Models.Commons.Zone;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	[RoutePrefix(@"api/zone")]
	public class ZoneController : BaseController
	{
		private readonly IZoneBl _zoneBl;

		public ZoneController(IZoneBl zoneBl)
		{
			_zoneBl = zoneBl;
		}

		// GET api/Zone
		public IEnumerable<Zone> Get()
		{
			return _zoneBl.GetAllValues();
		}

		// GET api/Zone/5
		public Zone Get(int id)
		{
			return _zoneBl.GetValueById(id);
		}

		// POST api/Zone
		public long Post([FromBody]Zone zone)
		{
			return _zoneBl.InsertValue(zone);
		}

		// PUT api/Zone
		public void Put([FromBody]Zone zone)
		{
			_zoneBl.UpdateValue(zone);
		}

		// DELETE api/Zone/5
		public void Delete(int id)
		{
			_zoneBl.DeleteValue(id);
		}

		// GET api/zone/GetByCity/5
		[Route(@"GetByCity/{id}")]
		public IEnumerable<Zone> GetByCity(int id)
		{
			return _zoneBl.GetByCity(id);
		}
	}
}