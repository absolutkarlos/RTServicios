using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	public class MaterialController : BaseController
	{
		private readonly IBusinessLayer<Material> _materialBl;

		public MaterialController(IBusinessLayer<Material> materialBl)
		{
			_materialBl = materialBl;
		}

		// GET api/Material
		public IEnumerable<Material> Get()
		{
			return _materialBl.GetAllValues();
		}

		// GET api/Material/5
		public Material Get(int id)
		{
			return _materialBl.GetValueById(id);
		}

		// POST api/Material
		public long Post([FromBody]Material material)
		{
			return _materialBl.InsertValue(material);
		}

		// PUT api/Material
		public void Put([FromBody]Material material)
		{
			_materialBl.UpdateValue(material);
		}

		// DELETE api/Material/5
		public void Delete(int id)
		{
			_materialBl.DeleteValue(id);
		}
	}
}