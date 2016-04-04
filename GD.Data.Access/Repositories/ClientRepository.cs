using System;
using System.Collections.Generic;
using System.Linq;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

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
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fclient_set", new Dictionary<string, object>
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

		public void Update(Client model)
		{
			DbContext.ExecuteStoredProcedure(@"rtsurvey.fclient_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<Client> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<Client>>(@"rtsurvey.fclient_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public Client GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Client>>(@"rtsurvey.fclient_get", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
			}).FirstOrDefault();
		}

		public Client GetInfo<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<List<Client>>(@"rtsurvey.fclientbyidclient_get", new Dictionary<string, object>
			{
				{
					@"_id", id
				}
			}).FirstOrDefault();
		}

		public int ValidateByRuc(string ruc)
		{
			var client = DbContext.ExecuteStoredProcedure<List<Client>>(@"rtsurvey.fclient_validate", new Dictionary<string, object>
			{
				{
					@"_ruc", ruc
				}
			}).FirstOrDefault();

			if (client != null)
				return (int)client.Id;
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