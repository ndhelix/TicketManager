using System;
using System.Collections.Generic;
using TicketMan.Platform.Protocol.ObjectModel.Orders;
using System.ComponentModel;
using TicketMan.Backoffice.Desktop.Core;
using TicketMan.Platform.Protocol.ObjectModel.Reservations;
using TicketMan.Platform.Protocol.ObjectModel.Finances;
using TicketMan.Platform.Protocol.ObjectModel.Contracts;
using TicketMan.Platform.Protocol.ObjectModel.Packages;
using TicketMan.Platform.Protocol.ObjectModel;

namespace TicketMan.Backoffice.Desktop.Decorators
{
	public class OrderDecorator : ProtocolElement
	{
		private readonly Order _component;

		public OrderDecorator(Order component)
		{
			_component = component;
		}

		/// <summary>
		///  Возвращает или устанавливает уникальный номер заявки в рамках TicketMan Platform.
		/// </summary>
		[DisplayName("Уникальный номер")]
		public string UniqueNumber
		{
			get { return _component.UniqueNumber; }
		}

		[DisplayName("Cвязи между клиентами и услугами")]
		public List<Arrangement> Arrangements { get { return _component.Arrangements; } }

		[DisplayName("Комментарии")]
		public List<Comment> Comments { get { return _component.Comments; } }

		private List<DealInfoDecorator> _deals;
		[DisplayName("Список сделок")]
		public List<DealInfoDecorator> Deals
		{
			get
			{
				return _deals ??
								 (_deals =
									_component.Deals != null
											? _component.Deals.ConvertAll(x => new DealInfoDecorator(x, LegalParties))
											: null);
			}
		}

		public List<OrderDocumentInfoDecorator> _documents;
		[DisplayName("Документы")]
		public List<OrderDocumentInfoDecorator> Documents
		{
			get
			{
				return _documents ??
								 (_documents =
									_component.Documents != null
											? _component.Documents.ConvertAll(x => new OrderDocumentInfoDecorator(x))
											: null);
			}
		}

		[DisplayName("Юридические лица")]
		public List<LegalParty> LegalParties { get { return _component.LegalParties; } }

		[DisplayName("Стоимость заявки в различных валютах")]
		public List<Price> Prices { get { return _component.Prices; } }

		private List<ClientDecorator> _clients;
		[DisplayName("Клиенты")]
		public List<ClientDecorator> Clients
		{
			get
			{
				return _clients ?? (_clients = _component.Clients != null
												? _component.Clients.ConvertAll(x => new ClientDecorator(x, _component.Arrangements.Find(y => y.ClientID == x.ID), _component.ServiceType))
												: null);
			}
		}

		/// <summary>
		/// Дата создания заявки
		/// </summary>
		[DisplayName("Дата создания")]
		public DateTime CreatedAt
		{
			get { return _component.CreatedAt; }
		}

		/// <summary>
		/// Текстовое описание заявки
		/// </summary>
		[DisplayName("Описание")]
		public string Description { get { return _component.Description; } }

		private List<ServiceDecorator> _services;
		[DisplayName("Услуги")]
		public List<ServiceDecorator> Services
		{
			get
			{
				return _services ??
								 (_services =
									_component.Services != null
											? _component.Services.ConvertAll(x => new ServiceDecorator(x))
											: null);
			}
		}

		[DisplayName("Базовая дата пакета")]
		public Date BaseDate { get { return _component.BaseDate; } }

		[DisplayName("Идентификатор контрагента-покупателя")]
		private long? BuyerID { get { return _component.BuyerID; } }

		[DisplayName("Пакет")]
		public string PackageID { get { return _component.PackageID; } }

		[DisplayName("Плательщик")]
		public Payer Payer { get { return _component.Payer; } }

		[DisplayName("Информация о платежах")]
		public PaymentDetails PaymentDetails { get { return _component.PaymentDetails; } }

		[DisplayName("Статус платежей по заявке в системе TicketMan Platform")]
		public OrderPaymentStatus PaymentStatus { get { return _component.PaymentStatus; } }

		[DisplayName("Детализация цены")]
		public PriceDetails PriceDetails { get { return _component.PriceDetails; } }

		[DisplayName("Идентификатор контрагента-продавца")]
		private long SellerID { get { return _component.SellerID; } }

		[DisplayName("Тип сервиса")]
		public ServiceType ServiceType { get { return _component.ServiceType; } }

		/// <summary>
		/// Статус заявки в системе TicketMan Platform
		/// </summary>
		[DisplayName("Статус")]
		public string Status
		{
			get { return EnumTranslator.Translate("OrderStatus", _component.Status.ToString()); }
		}

		[DisplayName("Идентификатор контрагента-поставщика")]
		private long VendorID { get { return _component.VendorID; } }

		[DisplayName("Флаги статуса заявки в системе вендора")]
		public OrderStatus VendorStatus { get { return _component.VendorStatus; } }

		[DisplayName("Уникальный номер заявки в рамках системы вендора")]
		public string VendorUniqueNumber { get { return _component.VendorUniqueNumber; } }

		public Order GetComponent()
		{
			return _component;
		}
	}
}
