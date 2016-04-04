using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	public class ClientTypeController : BaseController
	{
		private readonly IBusinessLayer<ClientType> _clientTypeBl;

		public ClientTypeController(IBusinessLayer<ClientType> clientTypeBl)
		{
			_clientTypeBl = clientTypeBl;
		}

		// GET api/ClientType
		public IEnumerable<ClientType> Get()
		{
			return _clientTypeBl.GetAllValues();
		}

		// GET api/ClientType/5
		public ClientType Get(int id)
		{
			return _clientTypeBl.GetValueById(id);
		}

		// POST api/ClientType
		public long Post([FromBody]ClientType clientType)
		{
			return _clientTypeBl.InsertValue(clientType);
		}

		// PUT api/ClientType/5
		public void Put([FromBody]ClientType clientType)
		{
			_clientTypeBl.UpdateValue(clientType);
		}

		// DELETE api/ClientType/5
		public void Delete(int id)
		{
			_clientTypeBl.DeleteValue(id);
		}
	}
}