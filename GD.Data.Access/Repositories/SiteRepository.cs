using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;
using NpgsqlTypes;

namespace GD.Data.Access.Repositories
{
	public class SiteRepository : ISiteRepository
	{
		private IDataAccessContext DbContext { get; }

		public SiteRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(Site model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fsite_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(Site model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fsite_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<Site> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<Site>>(@"rtsurvey.fsite_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public Site GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Site>>(@"rtsurvey.fsite_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = id }
			}).FirstOrDefault();
		}

		public IEnumerable<Site> GetByClient<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Site>>(@"rtsurvey.fsitebyclient_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = id }
			});
		}

		public void UpdateBuildingInformation(Site model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fsitebyidsite_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void UpdateLinkType(Site model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fsitebyidsite2_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
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