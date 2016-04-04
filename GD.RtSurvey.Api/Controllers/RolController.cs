using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	public class RolController : BaseController
	{
		private readonly IBusinessLayer<Rol> _rolBl;

		public RolController(IBusinessLayer<Rol> rolBl)
		{
			_rolBl = rolBl;
		}

		// GET api/Rol
		public IEnumerable<Rol> Get()
		{
			return _rolBl.GetAllValues();
		}

		// GET api/Rol/5
		public Rol Get(int id)
		{
			return _rolBl.GetValueById(id);
		}

		// POST api/Rol
		public long Post([FromBody]Rol rol)
		{
			return _rolBl.InsertValue(rol);
		}

		// PUT api/Rol
		public void Put([FromBody]Rol rol)
		{
			_rolBl.UpdateValue(rol);
		}

		// DELETE api/Rol/5
		public void Delete(int id)
		{
			_rolBl.DeleteValue(id);
		}
	}
}