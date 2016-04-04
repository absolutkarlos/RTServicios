using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	[RoutePrefix(@"api/entitychannel")]
	public class EntityChannelController : BaseController
	{
		private readonly IEntityChannelBl _entityChannelBl;

		public EntityChannelController(IEntityChannelBl entityChannelBl)
		{
			_entityChannelBl = entityChannelBl;
		}

		// GET api/EntityChannel
		public IEnumerable<EntityChannel> Get()
		{
			return _entityChannelBl.GetAllValues();
		}

		// GET api/EntityChannel/5
		public EntityChannel Get(int id)
		{
			return _entityChannelBl.GetValueById(id);
		}

		// POST api/EntityChannel
		public long Post([FromBody]EntityChannel entityChannel)
		{
			return _entityChannelBl.InsertValue(entityChannel);
		}

		// PUT api/EntityChannel
		public void Put([FromBody]EntityChannel entityChannel)
		{
			_entityChannelBl.UpdateValue(entityChannel);
		}

		// DELETE api/EntityChannel/5
		public void Delete(int id)
		{
			_entityChannelBl.DeleteValue(id);
		}

		// GET api/EntityChannel/GetByEntity/5
		[Route(@"GetByEntity/{id}")]
		public IEnumerable<EntityChannel> GetByEntity(int id)
		{
			return _entityChannelBl.GetByEntity(id);
		}

		// POST api/EntityChannel/InsertList
		[HttpPost]
		[Route(@"InsertList/")]
		public void InsertList(List<EntityChannel> entityChannels)
		{
			_entityChannelBl.InsertList(entityChannels);
		}
	}
}