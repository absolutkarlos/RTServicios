using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class CityRepository : ICityRepository
	{
		private IDataAccessContext DbContext { get; }

		public CityRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(City model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fcity_set", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(City model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fcity_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<City> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<City>>(@"rtsurvey.fcity_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public City GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<City>>(@"rtsurvey.fcity_get", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
			}).FirstOrDefault();
		}

		public IEnumerable<City> GetByState<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<City>>(@"rtsurvey.fcitybyidstate_get", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
			});
		}

		public bool Exists<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}