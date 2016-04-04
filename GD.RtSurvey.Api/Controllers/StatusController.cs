using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	public class StatusController : BaseController
	{
		private readonly IBusinessLayer<Status> _statusBl;

		public StatusController(IBusinessLayer<Status> statusBl)
		{
			_statusBl = statusBl;
		}

		// GET api/Status
		public IEnumerable<Status> Get()
		{
			return _statusBl.GetAllValues();
		}

		// GET api/Status/5
		public Status Get(int id)
		{
			return _statusBl.GetValueById(id);
		}

		// POST api/Status
		public long Post([FromBody]Status status)
		{
			return _statusBl.InsertValue(status);
		}

		// PUT api/Status
		public void Put([FromBody]Status status)
		{
			_statusBl.UpdateValue(status);
		}

		// DELETE api/Status/5
		public void Delete(int id)
		{
			_statusBl.DeleteValue(id);
		}
	}
}