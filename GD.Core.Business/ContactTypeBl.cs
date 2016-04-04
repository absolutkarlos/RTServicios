using System;
using System.Collections.Generic;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Models.Commons;

namespace GD.Core.Business
{
	public class ContactTypeBl : IBusinessLayer<ContactType>
	{
		private IRepository<ContactType> Repository { get; }

		public ContactTypeBl(IRepository<ContactType> repository)
		{
			Repository = repository;
		}

		public long InsertValue(ContactType model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValues(IEnumerable<ContactType> models)
		{
			foreach (var contactType in models)
			{
				Repository.Delete(contactType.Id);
			}
		}

		public void UpdateValues(IEnumerable<ContactType> models)
		{
			foreach (var contactType in models)
			{
				Repository.Update(contactType);
			}
		}

		public IEnumerable<ContactType> GetAllValues()
		{
			return Repository.GetAll();
		}

		public ContactType GetValueById<TId>(TId id)
		{
			return Repository.GetById(id);
		}

		public bool ExistsValue<TId>(TId id)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}