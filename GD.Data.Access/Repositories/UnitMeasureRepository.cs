using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class UnitMeasureRepository : IRepository<UnitMeasure>
	{
		private IDataAccessContext DbContext { get; }

		public UnitMeasureRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(UnitMeasure model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.funitmeasure_set", new Dictionary<string, object>
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

		public void Update(UnitMeasure model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.funitmeasure_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<UnitMeasure> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<UnitMeasure>>(@"rtsurvey.funitmeasure_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public UnitMeasure GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<UnitMeasure>>(@"rtsurvey.funitmeasure_get", new Dictionary<string, object>
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