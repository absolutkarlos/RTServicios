using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	public class AccessTypeController : BaseController
	{
		private readonly IBusinessLayer<AccessType> _accessTypeBl;

		public AccessTypeController(IBusinessLayer<AccessType> accessTypeBl)
		{
			_accessTypeBl = accessTypeBl;
		}

		// GET api/AccessType
		public IEnumerable<AccessType> Get()
		{
			return _accessTypeBl.GetAllValues();
		}

		// GET api/AccessType/5
		public AccessType Get(int id)
		{
			return _accessTypeBl.GetValueById(id);
		}

		// POST api/AccessType
		public long Post([FromBody]AccessType accessType)
		{
			return _accessTypeBl.InsertValue(accessType);
		}

		// PUT api/AccessType
		public void Put([FromBody]AccessType accessType)
		{
			_accessTypeBl.UpdateValue(accessType);
		}

		// DELETE api/AccessType/5
		public void Delete(int id)
		{
			_accessTypeBl.DeleteValue(id);
		}
	}
}