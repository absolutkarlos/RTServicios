using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	public class OrderStatusController : BaseController
	{
		private readonly IBusinessLayer<OrderStatus> _orderStatusBl;

		public OrderStatusController(IBusinessLayer<OrderStatus> orderStatusBl)
		{
			_orderStatusBl = orderStatusBl;
		}

		// GET api/OrderStatus
		public IEnumerable<OrderStatus> Get()
		{
			return _orderStatusBl.GetAllValues();
		}

		// GET api/OrderStatus/5
		public OrderStatus Get(int id)
		{
			return _orderStatusBl.GetValueById(id);
		}

		// POST api/OrderStatus
		public long Post([FromBody]OrderStatus orderStatus)
		{
			return _orderStatusBl.InsertValue(orderStatus);
		}

		// PUT api/OrderStatus
		public void Put([FromBody]OrderStatus orderStatus)
		{
			_orderStatusBl.UpdateValue(orderStatus);
		}

		// DELETE api/OrderStatus/5
		public void Delete(int id)
		{
			_orderStatusBl.DeleteValue(id);
		}
	}
}