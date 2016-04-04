using System;
using System.Collections.Generic;
using GD.Data.Access.DataAccess.Interface;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Data.Access.Repositories
{
	public class ContactTypeRepository : IRepository<ContactType>
	{
		private IDataAccessContext DbContext { get; }

		public ContactTypeRepository(IDataAccessContext dbContext)
		{
			DbContext = dbContext;
		}

		public long Insert(ContactType model)
		{
			return DbContext.ExecuteStoredProcedure<long>(@"rtsurvey.fcontacttype_set", new Dictionary<string, object>
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

		public void Update(ContactType model)
		{
			DbContext.ExecuteStoredProcedure<ContactType>(@"rtsurvey.fcontacttype_update", new Dictionary<string, object>
			{
				{
					@"_jsonvalue", model.ToJson()
				}
			});
		}

		public IEnumerable<ContactType> GetAll()
		{
			return DbContext.ExecuteStoredProcedure<List<ContactType>>(@"rtsurvey.fcontacttype_get", new Dictionary<string, object>
			{
				{
					@"_id", 0
				}
			});
		}

		public ContactType GetById<TId>(TId id)
		{
			return DbContext.ExecuteStoredProcedure<ContactType>(@"rtsurvey.fcontacttype_get", new Dictionary<string, object>
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