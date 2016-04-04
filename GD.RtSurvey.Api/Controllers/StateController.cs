using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	[RoutePrefix(@"api/state")]
	public class StateController : BaseController
	{
		private readonly IStateBl _stateBl;

		public StateController(IStateBl stateBl)
		{
			_stateBl = stateBl;
		}

		// GET api/State
		public IEnumerable<State> Get()
		{
			return _stateBl.GetAllValues();
		}

		// GET api/State/5
		public State Get(int id)
		{
			return _stateBl.GetValueById(id);
		}

		// POST api/State
		public long Post([FromBody]State state)
		{
			return _stateBl.InsertValue(state);
		}

		// PUT api/State
		public void Put([FromBody]State state)
		{
			_stateBl.UpdateValue(state);
		}

		// DELETE api/State/5
		public void Delete(int id)
		{
			_stateBl.DeleteValue(id);
		}

		// GET api/state/GetByCountry/5
		[Route(@"GetByCountry/{id}")]
		public IEnumerable<State> GetByClient(int id)
		{
			return _stateBl.GetByCountry(id);
		}
	}
}