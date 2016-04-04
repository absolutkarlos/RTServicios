using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	public class RolActionController : BaseController
	{
		private readonly IBusinessLayer<RolAction> _rolActionBl;

		public RolActionController(IBusinessLayer<RolAction> rolActionBl)
		{
			_rolActionBl = rolActionBl;
		}

		// GET api/RolAction
		public IEnumerable<RolAction> Get()
		{
			return _rolActionBl.GetAllValues();
		}

		// GET api/RolAction/5
		public RolAction Get(int id)
		{
			return _rolActionBl.GetValueById(id);
		}

		// POST api/RolAction
		public long Post([FromBody]RolAction rolAction)
		{
			return _rolActionBl.InsertValue(rolAction);
		}

		// PUT api/RolAction
		public void Put([FromBody]RolAction rolAction)
		{
			_rolActionBl.UpdateValue(rolAction);
		}

		// DELETE api/RolAction/5
		public void Delete(int id)
		{
			_rolActionBl.DeleteValue(id);
		}
	}
}