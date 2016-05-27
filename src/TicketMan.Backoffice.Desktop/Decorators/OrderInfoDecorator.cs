using System;
using System.Collections.Generic;
//using TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Payments;
using TicketMan.Platform.Protocol.ObjectModel.Orders;
using System.ComponentModel;
using TicketMan.Backoffice.Desktop.Core;

namespace TicketMan.Backoffice.Desktop.Decorators
{
	public class OrderInfoDecorator
	{
		private readonly OrderInfo _component;

		public OrderInfoDecorator(OrderInfo component)
		{
			_component = component;
			if (_component.TotalPrice == null)
			{
				_component.TotalPrice = new PriceInfo();
			}
		}

		/// <summary>
		///  Возвращает или устанавливает уникальный номер заявки в рамках TicketMan Platform.
		/// </summary>
		[DisplayName("Уникальный номер")]
		public string UniqueNumber
		{
			get { return _component.UniqueNumber; }
		}

		private List<ClientInfoDecorator> _client;

		[DisplayName("Клиент")]
		public List<ClientInfoDecorator> Client
		{
			get { return _client ?? (_client = new List<ClientInfoDecorator> { new ClientInfoDecorator(_component.Client) }); }
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

		private List<OrderPaymentReportInfoDecorator> _paymentReports;
		/// <summary>
		/// Информация о платежных отчетах
		/// </summary>
		[DisplayName("Оплаты")]
		public List<OrderPaymentReportInfoDecorator> PaymentReports
		{
			get
			{
				return _paymentReports ??
							 (_paymentReports =
								_component.PaymentReports != null
										? _component.PaymentReports.ConvertAll(x => new OrderPaymentReportInfoDecorator(x))
										: null);
			}
			set { _paymentReports = value; }
		}

		private List<OrderPaymentInfoDecorator> _payments;
		/// <summary>
		/// Информация о платежах
		/// </summary>
		[DisplayName("Платежи")]
		public List<OrderPaymentInfoDecorator> Payments
		{
			get
			{
				return _payments ??
							 (_payments =
								_component.Payments != null
										? _component.Payments.ConvertAll(x => new OrderPaymentInfoDecorator(x))
										: null);
			}
			set { _payments = value; }
		}

		/// <summary>
		/// Информация (имя) о сайте сделавшего заказ
		/// </summary>
		[DisplayName("Сайт")]
		public string OwnerName { get { return _component.SiteInfo.Owner.Name; } }

		/// <summary>
		/// Статус заявки в системе TicketMan Platform
		/// </summary>
		[DisplayName("Статус")]
		public string Status
		{
			get { return EnumTranslator.Translate("OrderStatus", _component.Status.ToString()); }
		}

		/// <summary>
		/// Итоговая стоимость заявки для туриста
		/// </summary>
		[DisplayName("Сумма")]
		public decimal Amount
		{
			get { return Math.Round(_component.TotalPrice.Amount, 2); }
		}

		/// <summary>
		/// Валюта
		/// </summary>
		[DisplayName("Валюта")]
		public string Currency
		{
			get { return _component.TotalPrice.Currency; }
		}

		private List<VendorInfoDecorator> _vendoresInfo;

		/// <summary>
		/// Информация о поставщиках услуг в контексте данной заявки
		/// </summary>
		[DisplayName("Поставщики")]
		public List<VendorInfoDecorator> VendoresInfo
		{
			get
			{
				return _vendoresInfo ??
							 (_vendoresInfo =
								_component.VendoresInfo != null
										? _component.VendoresInfo.ConvertAll(x => new VendorInfoDecorator(x))
										: null);
			}
			set { _vendoresInfo = value; }
		}
	}
}
