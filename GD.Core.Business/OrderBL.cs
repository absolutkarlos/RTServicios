using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using GD.Core.Business.Interfaces;
using GD.Models.Commons;
using GD.Data.Access.Interfaces;
using GD.Models.Commons.Utilities;

namespace GD.Core.Business
{
	public class OrderBl : IOrderBl
	{
		private IOrderRepository Repository { get; }
		private ISiteAccessTypeRepository SiteAccessTypeRepository { get; }
		private ISiteSheduleRepository SiteSheduleRepository { get; }
		private IOrderMaterialRepository OrderMaterialRepository { get; }
		private IOrderShotRepository OrderShotRepository { get; }
		private IOrderFlowRepository OrderFlowRepository { get; }
		private ISiteServiceTypeRepository SiteServiceTypeRepository { get; }
		private IEntityContactRepository EntityContactRepository { get; }
		private IEntityChannelRepository EntityChannelRepository { get; }
		private IRepository<EntityChannelType> EntityChannelTypeRepository { get; }
		private IRepository<ServiceType> ServiceTypeRepository { get; }

		public OrderBl(IOrderRepository repository, ISiteAccessTypeRepository siteAccessTypeRepository, ISiteSheduleRepository siteSheduleRepository, IOrderMaterialRepository orderMaterialRepository,
						IOrderShotRepository orderShotRepository, IOrderFlowRepository orderFlowRepository, ISiteServiceTypeRepository siteServiceTypeRepository, IEntityContactRepository entityContactRepository,
						IEntityChannelRepository entityChannelRepository, IRepository<EntityChannelType> entityChannelTypeRepository, IRepository<ServiceType> serviceTypeRepository)
		{
			Repository = repository;
			SiteAccessTypeRepository = siteAccessTypeRepository;
			SiteSheduleRepository = siteSheduleRepository;
			OrderMaterialRepository = orderMaterialRepository;
			OrderShotRepository = orderShotRepository;
			OrderFlowRepository = orderFlowRepository;
			SiteServiceTypeRepository = siteServiceTypeRepository;
			EntityContactRepository = entityContactRepository;
			EntityChannelRepository = entityChannelRepository;
			EntityChannelTypeRepository = entityChannelTypeRepository;
			ServiceTypeRepository = serviceTypeRepository;
		}

		public long InsertValue(Order model)
		{
			if (!model.IsNullOrEmpty())
			{
				var idOrder = Repository.Insert(model);
				OrderFlowRepository.Insert(new OrderFlow
				{
					Order = new Order
					{
						Id = (int)idOrder
					},
					OrderStatus = new OrderStatus
					{
						Id = (int)OrderStatus.Type.Nuevo
					},
					OrderNextStatus = new OrderStatus
					{
						Id = (int)OrderStatus.Type.Prefactibilidad
					},
					StimatedDateNextStep = DateTime.Now.AddDays(Convert.ToDouble(ConfigurationManager.AppSettings[@"StimatedDatePrefeasibility"])),
					Status = new Status
					{
						Id = (int)Status.Type.Espera
					},
					CreateAt = DateTime.Now,
					CreateBy = model.CreateBy
				});
				return idOrder;
			}
			return 0;
		}

		public void DeleteValue<TId>(TId id)
		{
			Repository.Delete(id);
		}

		public void UpdateValue(Order model)
		{
			Repository.Update(model);
		}

		public void UpdateStatus(Order model)
		{
			OrderFlowRepository.Insert(new OrderFlow
			{
				Order = new Order
				{
					Id = model.Id
				},
				OrderNextStatus = new OrderStatus
				{
					Id = model.OrderStatus.Id + 1
				},
				StimatedDateNextStep = DateTime.Now.AddDays((model.OrderStatus.Id + 1) == (int)OrderStatus.Type.Inspeccion
					? Convert.ToDouble(ConfigurationManager.AppSettings[@"StimatedDateInspection"])
					: Convert.ToDouble(ConfigurationManager.AppSettings[@"StimatedDateInstallation"])),
				OrderStatus = new OrderStatus
				{
					Id = model.OrderStatus.Id
				},
				Status = new Status
				{
					Id = model.Status.Id
				},
				CreateAt = DateTime.Now,
				CreateBy = model.CreateBy
			});
		}

		public void UpdateOrderInformation(Order order)
		{
			Repository.UpdateOrderInformation(order);
		}

		public IEnumerable<Order> GetAllValues()
		{
			return Repository.GetAll();
		}

		public Order GetValueById<TId>(TId id)
		{
			return Repository.GetById(id);
		}

		public IEnumerable<Order> GetByUser<TId>(TId id)
		{
			return Repository.GetByUser(id);
		}

		public Order GetInfo<TId>(TId id)
		{
			var order = Repository.GetInfo(id);
			if (!order.IsNullOrEmpty())
			{
				if (!order.Site.IsNullOrEmpty())
				{
					if (!order.Site.Client.IsNullOrEmpty())
					{
						var listcontacts = EntityContactRepository.GetByClient(order.Site.Client.Id).ToList();

						foreach (var entityContact in listcontacts)
						{
							var listEntityChannel = EntityChannelRepository.GetByEntity(entityContact.Id).ToList();

							foreach (var entityChannel in listEntityChannel)
							{
								entityChannel.EntityChannelType = EntityChannelTypeRepository.GetById(entityChannel.IdEntityChannelType);
							}

							entityContact.ListEntityChannels = new List<EntityChannel>(listEntityChannel);
						}

						order.Site.Client.ListEntityContact = new List<EntityContact>(listcontacts);
					}

					var listSiteServiceType = SiteServiceTypeRepository.GetBySite(order.Site.Id).ToList();


					foreach (var serviceType in listSiteServiceType)
					{
						var type = ServiceTypeRepository.GetById(serviceType.Id);
						serviceType.Name = type.Name;
						serviceType.Aka = type.Aka;
					}

					order.Site.ListServiceType = new List<ServiceType>(listSiteServiceType);

					var listOrderFlow = OrderFlowRepository.GetByOrder(order.Id).ToList();
					order.ListOrderFlow = new List<OrderFlow>(listOrderFlow);

					var listSiteSchedule = SiteSheduleRepository.GetBySite(order.Site.Id).ToList();
					order.Site.ListSiteSchedule = new List<SiteSchedule>(listSiteSchedule);

					var listAccessType = SiteAccessTypeRepository.GetBySite(order.Site.Id).ToList();
					order.Site.ListSiteAccessType = new List<SiteAccessType>(listAccessType);

					var listMaterials = OrderMaterialRepository.GetByOrder(order.Id).ToList();
					order.ListMaterials = new List<OrderMaterial>(listMaterials);

					var listOrderShots = OrderShotRepository.GetByOrder(order.Id).ToList();
					order.ListOrderShot = new List<OrderShot>(listOrderShots);
				}
			}

			return order;
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