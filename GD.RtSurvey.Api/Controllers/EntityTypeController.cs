using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	public class EntityTypeController : BaseController
	{
		private readonly IBusinessLayer<EntityType> _entityTypeBl;

		public EntityTypeController(IBusinessLayer<EntityType> entityTypeBl)
		{
			_entityTypeBl = entityTypeBl;
		}

		// GET api/EntityType
		public IEnumerable<EntityType> Get()
		{
			return _entityTypeBl.GetAllValues();
		}

		// GET api/EntityType/5
		public EntityType Get(int id)
		{
			return _entityTypeBl.GetValueById(id);
		}

		// POST api/EntityType
		public long Post([FromBody]EntityType entityType)
		{
			return _entityTypeBl.InsertValue(entityType);
		}

		// PUT api/EntityType
		public void Put([FromBody]EntityType entityType)
		{
			_entityTypeBl.UpdateValue(entityType);
		}

		// DELETE api/EntityType/5
		public void Delete(int id)
		{
			_entityTypeBl.DeleteValue(id);
		}
	}
}