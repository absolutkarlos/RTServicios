using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	public class ServiceTypeController : BaseController
	{
		private readonly IBusinessLayer<ServiceType> _serviceTypeBl;

		public ServiceTypeController(IBusinessLayer<ServiceType> serviceTypeBl)
		{
			_serviceTypeBl = serviceTypeBl;
		}

		// GET api/ServiceType
		public IEnumerable<ServiceType> Get()
		{
			return _serviceTypeBl.GetAllValues();
		}

		// GET api/ServiceType/5
		public ServiceType Get(int id)
		{
			return _serviceTypeBl.GetValueById(id);
		}

		// POST api/ServiceType
		public long Post([FromBody]ServiceType serviceType)
		{
			return _serviceTypeBl.InsertValue(serviceType);
		}

		// PUT api/ServiceType
		public void Put([FromBody]ServiceType serviceType)
		{
			_serviceTypeBl.UpdateValue(serviceType);
		}

		// DELETE api/ServiceType/5
		public void Delete(int id)
		{
			_serviceTypeBl.DeleteValue(id);
		}
	}
}