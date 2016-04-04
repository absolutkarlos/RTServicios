using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	public class OrderFlowController : BaseController
	{
		private readonly IBusinessLayer<OrderFlow> _orderFlowBl;

		public OrderFlowController(IBusinessLayer<OrderFlow> orderFlowBl)
		{
			_orderFlowBl = orderFlowBl;
		}

		// GET api/OrderFlow
		public IEnumerable<OrderFlow> Get()
		{
			return _orderFlowBl.GetAllValues();
		}

		// GET api/OrderFlow/5
		public OrderFlow Get(int id)
		{
			return _orderFlowBl.GetValueById(id);
		}

		// POST api/OrderFlow
		public long Post([FromBody]OrderFlow orderFlow)
		{
			return _orderFlowBl.InsertValue(orderFlow);
		}

		// PUT api/OrderFlow
		public void Put([FromBody]OrderFlow orderFlow)
		{
			_orderFlowBl.UpdateValue(orderFlow);
		}

		// DELETE api/OrderFlow/5
		public void Delete(int id)
		{
			_orderFlowBl.DeleteValue(id);
		}
	}
}