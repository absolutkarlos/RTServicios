using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	public class ContactTypeController : BaseController
	{
		private readonly IBusinessLayer<ContactType> _contactTypeBl;

		public ContactTypeController(IBusinessLayer<ContactType> contactTypeBl)
		{
			_contactTypeBl = contactTypeBl;
		}

		// GET api/ContactType
		public IEnumerable<ContactType> Get()
		{
			return _contactTypeBl.GetAllValues();
		}

		// GET api/ContactType/5
		public ContactType Get(int id)
		{
			return _contactTypeBl.GetValueById(id);
		}

		// POST api/ContactType
		public long Post([FromBody]ContactType contactType)
		{
			return _contactTypeBl.InsertValue(contactType);
		}

		// PUT api/ContactType/5
		public void Put([FromBody]IEnumerable<ContactType> contactTypeList)
		{
			_contactTypeBl.UpdateValues(contactTypeList);
		}

		// DELETE api/ContactType/5
		public void Delete([FromBody]IEnumerable<ContactType> contactTypeList)
		{
			_contactTypeBl.DeleteValues(contactTypeList);
		}
	}
}