using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	public class RadioBaseLineSightController : BaseController
	{
		private readonly IBusinessLayer<RadioBaseLineSight> _radioBaseLineSightBl;

		public RadioBaseLineSightController(IBusinessLayer<RadioBaseLineSight> radioBaseLineSightBl)
		{
			_radioBaseLineSightBl = radioBaseLineSightBl;
		}

		// GET api/RadioBaseLineSight
		public IEnumerable<RadioBaseLineSight> Get()
		{
			return _radioBaseLineSightBl.GetAllValues();
		}

		// GET api/RadioBaseLineSight/5
		public RadioBaseLineSight Get(int id)
		{
			return _radioBaseLineSightBl.GetValueById(id);
		}

		// POST api/RadioBaseLineSight
		public long Post([FromBody]RadioBaseLineSight radioBaseLineSight)
		{
			return _radioBaseLineSightBl.InsertValue(radioBaseLineSight);
		}

		// PUT api/RadioBaseLineSight
		public void Put([FromBody]RadioBaseLineSight radioBaseLineSight)
		{
			_radioBaseLineSightBl.UpdateValue(radioBaseLineSight);
		}

		// DELETE api/RadioBaseLineSight/5
		public void Delete(int id)
		{
			_radioBaseLineSightBl.DeleteValue(id);
		}
	}
}