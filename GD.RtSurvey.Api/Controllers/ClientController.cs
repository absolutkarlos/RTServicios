using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	[RoutePrefix(@"api/client")]
	public class ClientController : BaseController
	{
		private readonly IClientBl _clientBl;

		public ClientController(IClientBl clientBl)
		{
			_clientBl = clientBl;
		}

		// GET api/Client
		public IEnumerable<Client> Get()
		{
			return _clientBl.GetAllValues();
		}

		// GET api/Client/5
		public Client Get(int id)
		{
			return _clientBl.GetValueById(id);
		}

		// POST api/Client
		public long Post([FromBody]Client client)
		{
			return _clientBl.InsertValue(client);
		}

		// PUT api/Client/5
		public void Put([FromBody]Client client)
		{
			_clientBl.UpdateValue(client);
		}

		// DELETE api/Client/5
		public void Delete(int id)
		{
			_clientBl.DeleteValue(id);
		}

		// GET api/Client/GetInfo/5
		[Route(@"GetInfo/{id}")]
		public Client GetInfo(int id)
		{
			return _clientBl.GetInfo(id);
		}

		// GET api/Client/ValidateByRuc/1235
		[HttpGet]
		[Route(@"ValidateByRuc/{ruc}")]
		public int ValidateByRuc(string ruc)
		{
			return _clientBl.ValidateByRuc(ruc);
		}
	}
}