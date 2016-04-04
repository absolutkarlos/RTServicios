using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	[RoutePrefix(@"api/entitycontact")]
	public class EntityContactController : BaseController
	{
		private readonly IEntityContactBl _entityContactBl;

		public EntityContactController(IEntityContactBl entityContactBl)
		{
			_entityContactBl = entityContactBl;
		}

		// GET api/EntityContact
		public IEnumerable<EntityContact> Get()
		{
			return _entityContactBl.GetAllValues();
		}

		// GET api/EntityContact/5
		public EntityContact Get(int id)
		{
			return _entityContactBl.GetValueById(id);
		}

		// POST api/EntityContact
		public long Post([FromBody]EntityContact entityContact)
		{
			return _entityContactBl.InsertValue(entityContact);
		}

		// PUT api/EntityContact/5
		public void Put([FromBody]EntityContact entityContact)
		{
			_entityContactBl.UpdateValue(entityContact);
		}

		// DELETE api/EntityContact/5
		public void Delete(int id)
		{
			_entityContactBl.DeleteValue(id);
		}

		// GET api/EntityContact/GetByClient/5
		[Route(@"GetByClient/{id}")]
		public IEnumerable<EntityContact> GetByClient(int id)
		{
			return _entityContactBl.GetByClient(id);
		}
	}
}