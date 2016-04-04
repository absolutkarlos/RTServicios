using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class RolRepository : IRepository<Rol>
	{
		private IDataAccessContext DbContext { get; }

		public RolRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(Rol model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.frol_set", new Dictionary<string, object>
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

		public void Update(Rol model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.frol_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<Rol> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<Rol>>(@"rtsurvey.frol_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public Rol GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Rol>>(@"rtsurvey.frol_get", new Dictionary<string, object>
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