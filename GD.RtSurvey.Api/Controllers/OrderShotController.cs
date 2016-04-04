using System;
using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;
using GD.RtSurvey.Api.Controllers.Base;
using Newtonsoft.Json;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	[RoutePrefix(@"api/ordershot")]
	public class OrderShotController : BaseController
	{
		private readonly IOrderShotBl _orderShotBl;

		public OrderShotController(IOrderShotBl orderShotBl)
		{
			_orderShotBl = orderShotBl;
		}

		// GET api/OrderShot
		public IEnumerable<OrderShot> Get()
		{
			return _orderShotBl.GetAllValues();
		}

		// GET api/OrderShot/5
		public OrderShot Get(int id)
		{
			return _orderShotBl.GetValueById(id);
		}

		// POST api/OrderShot
		public long Post([FromBody]OrderShot orderShot)
		{
			return _orderShotBl.InsertValue(orderShot);
		}

		// PUT api/OrderShot
		public void Put([FromBody]OrderShot orderShot)
		{
			_orderShotBl.UpdateValue(orderShot);
		}

		// DELETE api/OrderShot/5
		public void Delete(int id)
		{
			_orderShotBl.DeleteValue(id);
		}

		// GET api/OrderShot/GetByOrder/5
		[Route(@"GetByOrder/{id}")]
		public IEnumerable<OrderShot> GetByOrder(int id)
		{
			return _orderShotBl.GetByOrder(id);
		}
	}
}