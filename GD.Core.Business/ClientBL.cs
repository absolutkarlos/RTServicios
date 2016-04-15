using System;
using System.Collections.Generic;
using System.Linq;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using GD.Data.Access.Repositories;
using GD.Models.Commons;
using GD.Models.Commons.Utilities;

namespace GD.Core.Business
{
	public class ClientBl : IClientBl
	{
		private IEntityContactRepository EntityContactRepository { get; }
		private IEntityChannelRepository EntityChannelRepository { get; }
		private IRepository<EntityChannelType> EntityChannelTypeRepository { get; }
		private IRepository<Country> CountryRepository { get; }
		private IRepository<State> StateRepository { get; }
		private IRepository<City> CityRepository { get; }
		private IRepository<Zone> ZoneRepository { get; }
		private IClientRepository Repository { get; }

		public ClientBl(IClientRepository repository, IEntityContactRepository entityContactRepository, IEntityChannelRepository entityChannelRepository,
						IRepository<EntityChannelType> entityChannelTypeRepository, IRepository<Country> countryRepository, IRepository<State> stateRepository,
						IRepository<City> cityRepository, IRepository<Zone> zoneRepository)
		{
			Repository = repository;
			EntityContactRepository = entityContactRepository;
			EntityChannelRepository = entityChannelRepository;
			EntityChannelTypeRepository = entityChannelTypeRepository;
			CountryRepository = countryRepository;
			StateRepository = stateRepository;
			CityRepository = cityRepository;
			ZoneRepository = zoneRepository;
		}

		public long InsertValue(Client model)
		{
			return Repository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(Client model)
		{
			Repository.Update(model);
		}

		public IEnumerable<Client> GetAllValues()
		{
			var clients = Repository.GetAll().ToList();

			if (clients.Any())
			{
				foreach (var client in clients)
				{
					client.Country = CountryRepository.GetById(client.IdCountry);
					client.State = StateRepository.GetById(client.IdState);
					client.City = CityRepository.GetById(client.IdCity);
					client.Zone = ZoneRepository.GetById(client.IdZone);
				}
			}
			return clients;
		}

		public Client GetValueById<TId>(TId id)
		{
			return Repository.GetById(id);
		}

		public Client GetInfo<TId>(TId id)
		{
			var client = Repository.GetInfo(id);

			if (!client.IsNullOrEmpty())
			{
				var listEntityContact = EntityContactRepository.GetByClient(client.Id).ToList();

				foreach (var entityContact in listEntityContact)
				{
					entityContact.Country = CountryRepository.GetById(entityContact.IdCountry);
					entityContact.State = StateRepository.GetById(entityContact.IdState);
					entityContact.City = CityRepository.GetById(entityContact.IdCity);
					entityContact.Zone = ZoneRepository.GetById(entityContact.IdZone);

					var listEntityChannel = EntityChannelRepository.GetByEntity(entityContact.Id).ToList();

					foreach (var entityChannel in listEntityChannel)
					{
						entityChannel.EntityChannelType = EntityChannelTypeRepository.GetById(entityChannel.IdEntityChannelType);
					}

					entityContact.ListEntityChannels = new List<EntityChannel>(listEntityChannel);
				}

				client.ListEntityContact = new List<EntityContact>(listEntityContact);
			}

			return client;
		}

		public int ValidateByRuc(string ruc)
		{
			return Repository.ValidateByRuc(ruc);
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