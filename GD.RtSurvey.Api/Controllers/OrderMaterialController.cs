using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	[RoutePrefix(@"api/ordermaterial")]
	public class OrderMaterialController : BaseController
	{
		private readonly IOrderMaterialBl _orderMaterialBl;

		public OrderMaterialController(IOrderMaterialBl orderMaterialBl)
		{
			_orderMaterialBl = orderMaterialBl;
		}

		// GET api/OrderMaterial
		public IEnumerable<OrderMaterial> Get()
		{
			return _orderMaterialBl.GetAllValues();
		}

		// GET api/OrderMaterial/5
		public OrderMaterial Get(int id)
		{
			return _orderMaterialBl.GetValueById(id);
		}

		// POST api/OrderMaterial
		public long Post([FromBody]OrderMaterial orderMaterial)
		{
			return _orderMaterialBl.InsertValue(orderMaterial);
		}

		// PUT api/OrderMaterial
		public void Put([FromBody]OrderMaterial orderMaterial)
		{
			_orderMaterialBl.UpdateValue(orderMaterial);
		}

		// DELETE api/OrderMaterial/5
		public void Delete(int id)
		{
			_orderMaterialBl.DeleteValue(id);
		}

		// DELETE api/OrderMaterial/DeleteByOrder/5
		[HttpDelete]
		[Route(@"DeleteByOrder/{id}")]
		public void DeleteByOrder(int id)
		{
			_orderMaterialBl.DeleteByOrder(id);
		}

		// GET api/OrderMaterial/GetByOrder/5
		[Route(@"GetByOrder/{id}")]
		public IEnumerable<OrderMaterial> GetByOrder(int id)
		{
			return _orderMaterialBl.GetByOrder(id);
		}

		// POST api/OrderMaterial
		[HttpPost]
		[Route(@"InsertList/")]
		public void InsertList([FromBody]List<OrderMaterial> orderMaterials)
		{
			_orderMaterialBl.InsertList(orderMaterials);
		}
	}
}