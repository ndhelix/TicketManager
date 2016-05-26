using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TicketMan.Backoffice.Desktop.Core;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Payments;

namespace TicketMan.Backoffice.Desktop.Decorators
{
	public class PaymentDecorator
	{
		private readonly Payment _component;

		[DisplayName("Уникальный номер")]
		public string UniqueNumber { get { return _component.UniqueNumber; } }

		[DisplayName("Плательщик")]
		public string Sender { get { return _component.Sender.Name; } }

		[DisplayName("Дата платежа")]
		public DateTime PaymentDate { get { return _component.PaymentDate; } }

		[DisplayName("Тип платежа")]
		public string PaymentType { get { return EnumTranslator.Translate("PaymentType", _component.PaymentType.ToString()); } }

		[DisplayName("Сумма")]
		public decimal Amount { get { return _component.Amount; } }

		[DisplayName("Код валюты в которой производится расчет")]
		public string CurrencyCode { get { return _component.CurrencyCode; } }
		
		[DisplayName("Комментарий менеджера")]
		public string Comment { get { return _component.Comment; } }

	
		//[DisplayName("Дата создания")]
		//public DateTime CreatedAt { get { return _component.CreatedAt; } }
				
		
		[DisplayName("Описание, основание платежа")]
		public string Description { get { return _component.Description; } }
				
		[DisplayName("Внешний номер платежа")]
		public string ExternalNumber { get { return _component.ExternalNumber; } }
				
		[DisplayName("Внесен вручную")]
		public bool IsManual { get { return _component.IsManual; } }
				
		[DisplayName("Разнесен")]
		public bool IsPosted { get { return _component.IsPosted; } }
				
		//[DisplayName("Время последнего обновления")]
		//public DateTime LastUpdate { get { return _component.LastUpdate; } }
				


		public PaymentDecorator(Payment component)
		{
			_component = component;
		}
	}
}
