using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	public class UnitMeasureController : BaseController
	{
		private readonly IBusinessLayer<UnitMeasure> _unitMeasureBl;

		public UnitMeasureController(IBusinessLayer<UnitMeasure> unitMeasureBl)
		{
			_unitMeasureBl = unitMeasureBl;
		}

		// GET api/UnitMeasure
		public IEnumerable<UnitMeasure> Get()
		{
			return _unitMeasureBl.GetAllValues();
		}

		// GET api/UnitMeasure/5
		public UnitMeasure Get(int id)
		{
			return _unitMeasureBl.GetValueById(id);
		}

		// POST api/UnitMeasure
		public long Post([FromBody]UnitMeasure unitMeasure)
		{
			return _unitMeasureBl.InsertValue(unitMeasure);
		}

		// PUT api/UnitMeasure
		public void Put([FromBody]UnitMeasure unitMeasure)
		{
			_unitMeasureBl.UpdateValue(unitMeasure);
		}

		// DELETE api/UnitMeasure/5
		public void Delete(int id)
		{
			_unitMeasureBl.DeleteValue(id);
		}
	}
}