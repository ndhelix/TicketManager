using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using TicketMan.Platform.Protocol.ObjectModel.Info;
using TicketMan.Platform.Protocol.ObjectModel.Orders;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel;
using System.ComponentModel;
using TicketMan.Platform.Protocol.ObjectModel.Contracts;
using TicketMan.Platform.Protocol.ObjectModel.Finances;

namespace TicketMan.Backoffice.Desktop.Decorators
{


	public class ClientInfoDecorator
	{
		private readonly ClientInfo _component;
		/// <summary>
		///     Электронная почта
		/// </summary>
		public string Email { get { return _component.Email; } }
		/// <summary>
		///     Имя и фамилия
		/// </summary>
		[DisplayName("Имя")]
		public string Name { get { return _component.FirstName + " " + _component.LastName; ; } }
		/// <summary>
		///     Номер телефона
		/// </summary>
		[DisplayName("Телефон")]
		public string Phone { get { return _component.Phone; } }

		public ClientInfoDecorator(ClientInfo component)
		{
			_component = component;
		}
	}

	public class OrderPaymentReportInfoDecorator : PaymentReportInfo
	{
		private readonly PaymentReportInfo _component;
		/// <summary>
		///     Дата создания платежа
		/// </summary>
		[DisplayName("Дата создания")]
		public new DateTime CreatedAt { get { return _component.CreatedAt; } }
		/// <summary>
		///     Система через которую осуществлена оплата
		/// </summary>
		[DisplayName("Система")]
		public new string PaymentSystemParty { get { return _component.PaymentSystemParty.Name; } }
		/// <summary>
		///     Размер оплаты
		/// </summary>
		[DisplayName("Размер оплаты")]
		public new string Value { get { return _component.Value.Amount.ToString("0.00") + " " + _component.Value.Currency; } }

		public OrderPaymentReportInfoDecorator(PaymentReportInfo component)
		{
			this._component = component;
		}
	}

	public class OrderPaymentInfoDecorator 
	{
		private readonly PaymentInfo _component;

		[DisplayName("Дата создания")]
		public new DateTime CreatedAt { get { return _component.CreatedAt; } }

		[DisplayName("Плательщик")]
		public new string PaymentSystemParty { get { return _component.Sender.Name; } }

		[DisplayName("Размер оплаты")]
		public new string Value { get { return _component.Value.Amount.ToString("0.00") + " " + _component.Value.Currency; } }

		public OrderPaymentInfoDecorator(PaymentInfo component)
		{
			this._component = component;
		}
	}

	public class OrganizationInfoDecorator
	{
		private readonly OrganizationInfo _component;

		[DisplayName("Код организации")]
		public string Code { get { return _component.Code; } }

		[DisplayName("Полное название")]
		public string FullName { get { return _component.FullName; } }

		[DisplayName("Идентификатор контрагента")]
		public long PartyId { get { return _component.PartyId; } }

		//[DisplayName("Краткое название")]
		//public string ShortName { get { return _component.ShortName; } }

		public OrganizationInfoDecorator(OrganizationInfo component)
		{
			this._component = component;
		}

	}

	public class VendorInfoDecorator
	{
		private readonly VendorInfo _component;

		/// <summary>
		///     Код поставщика
		/// </summary>
		[DisplayName("Код поставщика")]
		public string Code { get { return _component.Code; } }
		/// <summary>
		///     Название поставщика
		/// </summary>
		[DisplayName("Название")]
		public string Name { get { return _component.Name; } }
		[DisplayName("Тип сервиса")]
		public TicketMan.Platform.Protocol.ObjectModel.Contracts.ServiceType ServiceType { get { return _component.ServiceType; } }
		//
		/// <summary>
		//     Статус заявки в системе вендора
		/// </summary>
		[DisplayName("Статус заявки")]
		public OrderStatus Status { get { return _component.Status; } }
		/// <summary>
		///     Уникальный номер заявки в рамках системы вендора.
		/// </summary>
		[DisplayName("Уникальный номер заявки в рамках системы вендора")]
		public string UniqueNumber { get { return _component.UniqueNumber; } }

		public VendorInfoDecorator(VendorInfo component)
		{
			_component = component;
		}
	}

	public class DealInfoDecorator
	{
		private readonly DealInfo _component;
		List<LegalParty> _legalParties;
		public DealInfoDecorator(DealInfo component, List<LegalParty> legalParties)
		{
			_component = component;
			_legalParties = legalParties;
		}

		[DisplayName("Сумма долга продавца перед покупателем")]
		public decimal Amount { get { return Math.Round(_component.Amount, 2); } }

		[DisplayName("ID покупателя")]
		private long BuyerPartyId { get { return _component.BuyerPartyID; } }

		[DisplayName("Покупатель")]
		public string Buyer { get { return _legalParties.Find(x => x.ID == _component.BuyerPartyID).FullName; } }

		[DisplayName("ID контракта")]
		public long ContractId { get { return _component.ContractId; } }
		
		[DisplayName("Тип контракта")]
		public ContractType ContractType { get { return _component.ContractType; } }
		
		[DisplayName("ID продавца")]
		private long SellerPartyId { get { return _component.SellerPartyID; } }

		[DisplayName("Продавец")]
		public string Seller { get { return _legalParties.Find(x => x.ID == _component.SellerPartyID).FullName; } }

	}


	public class OrderDocumentInfoDecorator
	{
		private readonly OrderDocumentInfo _component;
		public OrderDocumentInfoDecorator(OrderDocumentInfo component)
		{
			_component = component;
		}

		[DisplayName("Идентификатор клиента")]
		public long? ClientID { get { return _component.ClientID; } }
	
		[DisplayName("Код документа")]
		public string Code { get { return _component.Code; } }
		
		[DisplayName("Описание")]
		public string Description { get { return _component.Description; } }
		
		[DisplayName("Адреc для скачивания")]
		public string LocationUrl { get { return _component.LocationUrl; } }
		
		[DisplayName("Название")]
		public string Name { get { return _component.Name; } }
	}

}