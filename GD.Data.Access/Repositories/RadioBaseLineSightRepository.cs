using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class RadioBaseLineSightRepository : IRepository<RadioBaseLineSight>
	{
		private IDataAccessContext DbContext { get; }

		public RadioBaseLineSightRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(RadioBaseLineSight model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fradiobaselinesight_set", new Dictionary<string, object>
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

		public void Update(RadioBaseLineSight model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fradiobaselinesight_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<RadioBaseLineSight> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<RadioBaseLineSight>>(@"rtsurvey.fradiobaselinesight_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public RadioBaseLineSight GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<RadioBaseLineSight>>(@"rtsurvey.fradiobaselinesight_get", new Dictionary<string, object>
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