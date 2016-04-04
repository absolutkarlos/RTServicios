using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class MaterialRepository : IRepository<Material>
	{
		private IDataAccessContext DbContext { get; }

		public MaterialRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(Material model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fmaterial_set", new Dictionary<string, object>
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

		public void Update(Material model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fmaterial_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<Material> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<Material>>(@"rtsurvey.fmaterial_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public Material GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Material>>(@"rtsurvey.fmaterial_get", new Dictionary<string, object>
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