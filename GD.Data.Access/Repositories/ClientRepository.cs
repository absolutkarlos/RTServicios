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
	public class ClientRepository : IClientRepository
	{
		private IDataAccessContext DbContext { get; }

		public ClientRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(Client model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fclient_set", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public void Delete<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Update(Client model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fclient_update", new List<Parameter>
			{
				new Parameter { Key = @"_jsonvalue", DbType = NpgsqlDbType.Json, Value = model.ToJson() }
			});
		}

		public IEnumerable<Client> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<Client>>(@"rtsurvey.fclient_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = 0 }
			});
		}

		public Client GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Client>>(@"rtsurvey.fclient_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = id }
			}).FirstOrDefault();
		}

		public Client GetInfo<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Client>>(@"rtsurvey.fclientbyidclient_get", new List<Parameter>
			{
				new Parameter { Key = @"_id", DbType = NpgsqlDbType.Integer, Value = id }
			}).FirstOrDefault();
		}

		public int ValidateByRuc(string ruc)
		{
			var client = DbContext.ExecuteStoredProcedure<List<Client>>(@"rtsurvey.fclient_validate", new List<Parameter>
			{
				new Parameter { Key = @"_ruc", DbType = NpgsqlDbType.Varchar, Value = ruc }
			}).FirstOrDefault();

			if (client != null)
				return (int)client.Id;
			return 0;
		}

		public int ValidateByRuc(Client client)
		{
			var result = DbContext.ExecuteStoredProcedure<List<Client>>(@"rtsurvey.fclient_validate", new List<Parameter>
			{
				new Parameter { Key = @"_ruc", DbType = NpgsqlDbType.Varchar, Value = client.Ruc },
				new Parameter { Key = @"_idcountry", DbType = NpgsqlDbType.Integer, Value = client.Country.Id }
			}).FirstOrDefault();

			if (result != null)
				return (int)result.Id;
			return 0;
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