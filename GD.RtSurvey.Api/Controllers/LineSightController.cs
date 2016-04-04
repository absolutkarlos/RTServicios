using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	public class LineSightController : BaseController
	{
		private readonly IBusinessLayer<LineSight> _lineSightBl;

		public LineSightController(IBusinessLayer<LineSight> lineSightBl)
		{
			_lineSightBl = lineSightBl;
		}

		// GET api/LineSight
		public IEnumerable<LineSight> Get()
		{
			return _lineSightBl.GetAllValues();
		}

		// GET api/LineSight/5
		public LineSight Get(int id)
		{
			return _lineSightBl.GetValueById(id);
		}

		// POST api/LineSight
		public long Post([FromBody]LineSight lineSight)
		{
			return _lineSightBl.InsertValue(lineSight);
		}

		// PUT api/LineSight/5
		public void Put([FromBody]LineSight lineSight)
		{
			_lineSightBl.UpdateValue(lineSight);
		}

		// DELETE api/LineSight/5
		public void Delete(int id)
		{
			_lineSightBl.DeleteValue(id);
		}
	}
}