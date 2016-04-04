using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	public class OrderShotTypeController : BaseController
	{
		private readonly IBusinessLayer<OrderShotType> _orderShotTypeBl;

		public OrderShotTypeController(IBusinessLayer<OrderShotType> orderShotTypeBl)
		{
			_orderShotTypeBl = orderShotTypeBl;
		}

		// GET api/OrderShotType
		public IEnumerable<OrderShotType> Get()
		{
			return _orderShotTypeBl.GetAllValues();
		}

		// GET api/OrderShotType/5
		public OrderShotType Get(int id)
		{
			return _orderShotTypeBl.GetValueById(id);
		}

		// POST api/OrderShotType
		public long Post([FromBody]OrderShotType orderShotType)
		{
			return _orderShotTypeBl.InsertValue(orderShotType);
		}

		// PUT api/OrderShotType
		public void Put([FromBody]OrderShotType orderShotType)
		{
			_orderShotTypeBl.UpdateValue(orderShotType);
		}

		// DELETE api/OrderShotType/5
		public void Delete(int id)
		{
			_orderShotTypeBl.DeleteValue(id);
		}
	}
}