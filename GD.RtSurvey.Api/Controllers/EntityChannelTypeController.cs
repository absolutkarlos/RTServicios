using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	public class EntityChannelTypeController : BaseController
	{
		private readonly IBusinessLayer<EntityChannelType> _entityChannelTypeBl;

		public EntityChannelTypeController(IBusinessLayer<EntityChannelType> entityChannelTypeBl)
		{
			_entityChannelTypeBl = entityChannelTypeBl;
		}

		// GET api/EntityChannelType
		public IEnumerable<EntityChannelType> Get()
		{
			return _entityChannelTypeBl.GetAllValues();
		}

		// GET api/EntityChannelType/5
		public EntityChannelType Get(int id)
		{
			return _entityChannelTypeBl.GetValueById(id);
		}

		// POST api/EntityChannelType
		public long Post([FromBody]EntityChannelType entityChannelType)
		{
			return _entityChannelTypeBl.InsertValue(entityChannelType);
		}

		// PUT api/EntityChannelType/5
		public void Put([FromBody]EntityChannelType entityChannelType)
		{
			_entityChannelTypeBl.UpdateValue(entityChannelType);
		}

		// DELETE api/EntityChannelType/5
		public void Delete(int id)
		{
			_entityChannelTypeBl.DeleteValue(id);
		}
	}
}