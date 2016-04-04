using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	public class CountryController : BaseController
	{
		private readonly IBusinessLayer<Country> _countryBl;

		public CountryController(IBusinessLayer<Country> countryBl)
		{
			_countryBl = countryBl;
		}

		// GET api/Country
		public IEnumerable<Country> Get()
		{
			return _countryBl.GetAllValues();
		}

		// GET api/Country/5
		public Country Get(int id)
		{
			return _countryBl.GetValueById(id);
		}

		// POST api/Country
		public long Post([FromBody]Country country)
		{
			return _countryBl.InsertValue(country);
		}

		// PUT api/Country
		public void Put([FromBody]Country country)
		{
			_countryBl.UpdateValue(country);
		}

		// DELETE api/Country/5
		public void Delete([FromBody]IEnumerable<Country> countryList)
		{
			_countryBl.DeleteValue(countryList);
		}
	}
}