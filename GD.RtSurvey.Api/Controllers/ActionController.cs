using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.RtSurvey.Api.Controllers.Base;
using Action = GD.Models.Commons.Action;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	public class ActionController : BaseController
	{
		private readonly IBusinessLayer<Action> _actionBl;

		public ActionController(IBusinessLayer<Action> actionBl)
		{
			_actionBl = actionBl;
		}

		// GET api/Action
		public IEnumerable<Action> Get()
		{
			return _actionBl.GetAllValues();
		}

		// GET api/Action/5
		public Action Get(int id)
		{
			return _actionBl.GetValueById(id);
		}

		// POST api/Action
		public long Post([FromBody]Action action)
		{
			return _actionBl.InsertValue(action);
		}

		// PUT api/Action
		public void Put([FromBody]Action action)
		{
			_actionBl.UpdateValue(action);
		}

		// DELETE api/Action/5
		public void Delete(int id)
		{
			_actionBl.DeleteValue(id);
		}
	}
}
