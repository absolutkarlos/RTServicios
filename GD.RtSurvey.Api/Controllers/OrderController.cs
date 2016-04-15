using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	[RoutePrefix(@"api/order")]
	public class OrderController : BaseController
	{
		private readonly IOrderBl _orderBl;

		public OrderController(IOrderBl orderBl)
		{
			_orderBl = orderBl;
		}

		// GET api/Order
		public IEnumerable<Order> Get()
		{
			return _orderBl.GetAllValues();
		}

		// GET api/Order/5
		public Order Get(int id)
		{
			return _orderBl.GetValueById(id);
		}

		// POST api/Order
		public long Post([FromBody]Order order)
		{
			return _orderBl.InsertValue(order);
		}

		// PUT api/Order/5
		public void Put([FromBody]Order order)
		{
			_orderBl.UpdateValue(order);
		}

		// DELETE api/Order/5
		public void Delete(int id)
		{
			_orderBl.DeleteValue(id);
		}

		// GET api/Order/GetByUser/5
		[Route(@"GetByUser/{id}")]
		public IEnumerable<Order> GetByUser(int id)
		{
			return _orderBl.GetByUser(id);
		}

		// GET api/Order/GetInfo/5
		[Route(@"GetInfo/{id}")]
		public Order GetInfo(int id)
		{
			return _orderBl.GetInfo(id);
		}

		// PUT api/Order/UpdateStatus
		[HttpPut]
		[Route(@"UpdateStatus/")]
		public long UpdateStatus([FromBody]Order order)
		{
			return _orderBl.UpdateStatus(order);
		}

		// PUT api/Order/UpdateInformation/
		[HttpPut]
		[Route(@"UpdateInformation/")]
		public void UpdateInformation([FromBody]Order order)
		{
			_orderBl.UpdateOrderInformation(order);
		}

		// PUT api/Order/UpdateSettingUp/
		[HttpPut]
		[Route(@"UpdateSettingUp/")]
		public void UpdateSettingUp([FromBody]Order order)
		{
			_orderBl.UpdateOrderSettingUp(order);
		}
	}
}