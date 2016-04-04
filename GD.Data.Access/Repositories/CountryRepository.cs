using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class CountryRepository : IRepository<Country>
	{
		private IDataAccessContext DbContext { get; }

		public CountryRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(Country model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fcountry_set", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public void Delete<TId>(TId models)
		{
			throw new NotImplementedException();
		}

		public void Update(Country model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fcountry_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<Country> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<Country>>(@"rtsurvey.fcountry_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public Country GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Country>>(@"rtsurvey.fcountry_get", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
			}).FirstOrDefault();
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