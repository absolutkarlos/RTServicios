using System.Collections.Generic;
using System.Web.Http;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.RtSurvey.Api.Controllers.Base;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	[RoutePrefix(@"api/city")]
	public class CityController : BaseController
	{
		private readonly ICityBl _cityBl;

		public CityController(ICityBl cityBl)
		{
			_cityBl = cityBl;
		}

		// GET api/City
		public IEnumerable<City> Get()
		{
			return _cityBl.GetAllValues();
		}

		// GET api/City/5
		public City Get(int id)
		{
			return _cityBl.GetValueById(id);
		}

		// POST api/City
		public long Post([FromBody]City city)
		{
			return _cityBl.InsertValue(city);
		}

		// PUT api/City
		public void Put([FromBody]City city)
		{
			_cityBl.UpdateValue(city);
		}

		// DELETE api/City/5
		public void Delete(int id)
		{
			_cityBl.DeleteValue(id);
		}

		// GET api/city/GetByState/5
		[Route(@"GetByState/{id}")]
		public IEnumerable<City> GetByState(int id)
		{
			return _cityBl.GetByState(id);
		}
	}
}