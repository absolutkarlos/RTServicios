using System.Collections.Generic;
using System.Web.Http;
using GD.Models.Commons;
using GD.Core.Business.Interfaces;

namespace GD.RtSurvey.Api.Controllers
{
	[Authorize]
	public class UserController : ApiController
	{
		private readonly IUserBl _userBl;

		public UserController(IUserBl userBl)
		{
			_userBl = userBl;
		}

		// GET api/user
		public IEnumerable<User> Get()
		{
			return _userBl.GetAllValues();
		}

		// GET api/user/5
		public User Get(int id)
		{
			return _userBl.GetValueById(id);
		}

		// POST api/user
		public long Post([FromBody]User user)
		{
			return _userBl.InsertValue(user);
		}

		// PUT api/user
		public void Put([FromBody]User user)
		{
			_userBl.UpdateValue(user);
		}

		// DELETE api/user/5
		public void Delete(int id)
		{
			_userBl.DeleteValue(id);
		}
	}
}
