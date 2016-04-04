using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	public class PositionController : BaseController
	{
		private readonly IBusinessLayer<Position> _positionBl;

		public PositionController(IBusinessLayer<Position> positionBl)
		{
			_positionBl = positionBl;
		}

		// GET api/Position
		public IEnumerable<Position> Get()
		{
			return _positionBl.GetAllValues();
		}

		// GET api/Position/5
		public Position Get(int id)
		{
			return _positionBl.GetValueById(id);
		}

		// POST api/Position
		public long Post([FromBody]Position position)
		{
			return _positionBl.InsertValue(position);
		}

		// PUT api/Position
		public void Put([FromBody]Position position)
		{
			_positionBl.UpdateValue(position);
		}

		// DELETE api/Position/5
		public void Delete(int id)
		{
			_positionBl.DeleteValue(id);
		}
	}
}