using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.RtSurvey.Api.Controllers.Base;
using Audit = GD.Models.Commons.Audit;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	public class AuditController : BaseController
	{
		private readonly IBusinessLayer<Audit> _auditBl;

		public AuditController(IBusinessLayer<Audit> auditBl)
		{
			_auditBl = auditBl;
		}

		// GET api/Audit
		public IEnumerable<Audit> Get()
		{
			return _auditBl.GetAllValues();
		}

		// GET api/Audit/5
		public Audit Get(int id)
		{
			return _auditBl.GetValueById(id);
		}

		// POST api/Audit
		public long Post([FromBody]Audit audit)
		{
			return _auditBl.InsertValue(audit);
		}

		// PUT api/Audit
		public void Put([FromBody]Audit audit)
		{
			_auditBl.UpdateValue(audit);
		}

		// DELETE api/Audit/5
		public void Delete(int id)
		{
			_auditBl.DeleteValue(id);
		}
	}
}