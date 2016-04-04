using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	public class RadioBaseController : BaseController
	{
		private readonly IBusinessLayer<RadioBase> _radioBaseBl;

		public RadioBaseController(IBusinessLayer<RadioBase> radioBaseBl)
		{
			_radioBaseBl = radioBaseBl;
		}

		// GET api/RadioBase
		public IEnumerable<RadioBase> Get()
		{
			return _radioBaseBl.GetAllValues();
		}

		// GET api/RadioBase/5
		public RadioBase Get(int id)
		{
			return _radioBaseBl.GetValueById(id);
		}

		// POST api/RadioBase
		public long Post([FromBody]RadioBase radioBase)
		{
			return _radioBaseBl.InsertValue(radioBase);
		}

		// PUT api/RadioBase
		public void Put([FromBody]RadioBase radioBase)
		{
			_radioBaseBl.UpdateValue(radioBase);
		}

		// DELETE api/RadioBase/5
		public void Delete(int id)
		{
			_radioBaseBl.DeleteValue(id);
		}
	}
}