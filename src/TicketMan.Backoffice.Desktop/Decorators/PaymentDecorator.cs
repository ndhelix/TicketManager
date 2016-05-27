using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TicketMan.Backoffice.Desktop.Core;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Payments;
using TicketMan.Platform.Protocol.ObjectModel.Reservations;

namespace TicketMan.Backoffice.Desktop.Decorators
{
    // Summary:
    //     Представляет платеж по заявке с уникальным номером TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Payments.Payment.OrderUniqueNumber.
    [Serializable]
    public class Payment
    {
        // Summary:
        //     Создает новый экземпляр класса TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Payments.Payment.
        public Payment(){}
        //
        // Summary:
        //     Создает новый экземпляр класса TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Payments.Payment.
        //
        // Parameters:
        //   orderNumber:
        //
        //   currencyID:
        //
        //   amount:
        public Payment( string orderNumber, long currencyID, decimal amount ){}

        // Summary:
        //     Возвращает или устанавливает сумму платежа в валюте TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Payments.Payment.CurrencyID.
        public decimal Amount { get; set; }
        //
        // Summary:
        //     Возвращает или устанавливает идентификатор контрагента-получателя платежа.
        public long? BeneficiaryPartyID { get; set; }
        //
        // Summary:
        //     Возвращает или устанавливает комментарий к платежу.
        public string Comment { get; set; }
        //
        // Summary:
        //     Возвращает или устанавливает дату создания платежа.
        public DateTime CreatedAt { get; set; }
        //
        // Summary:
        //     Возвращает или устанавливает идентификатор валюты, в которой производится
        //     платеж.
        public long CurrencyID { get; set; }
        //
        // Summary:
        //     Возвращает или устанавливает номер заявки, которая оплачивается текущим платежом.
        //
        // Remarks:
        //     См. TicketMan.Platform.Protocol.ObjectModel.Orders.Order.UniqueNumber.
        public string OrderUniqueNumber { get; set; }
        //
        // Summary:
        //     Возвращает или устанавливает информацию о плательщике.
        public Client Payer { get; set; }
        //
        // Summary:
        //     Возвращает или устанавливает юридический статус плательщика.
        public PayerLegalStatus PayerLegalStatus { get; set; }
        //
        // Summary:
        //     Возвращает или устанавливает идентификатор контрагента-плательщика.
        //
        // Remarks:
        //     Если значение TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Payments.Payment.PayerPartyID
        //     равно null, за плательщика принимается покупатель заявки.
        public long? PayerPartyID { get; set; }
        //
        // Summary:
        //     Возвращает или устанавливает идентификатор платежной системы, через который
        //     был проведен данный платеж.
        public long? PaymentSystemID { get; set; }
        //
        // Summary:
        //     Возвращает или устанавливает код платежной системы.
        public string PaymentSystemUniformCode { get; set; }
        //
        // Summary:
        //     Возвращает или устанавливает уникальный номер платежа в пределах системы
        //     платежной системы.
        public string PaymentSystemUniqueNumber { get; set; }
        //
        // Summary:
        //     Возвращает или устанавливает тип платежа.
        public PaymentType Type { get; set; }
        //
        // Summary:
        //     Возвращает или устанавливает уникальный нормер платежа в пределах TicketMan
        //     Platform.
        public string UniqueNumber { get; set; }
    }

    public class PaymentDecorator
	{
		private readonly Payment _component;

		[DisplayName("Уникальный номер")]
		public string UniqueNumber { get { return _component.UniqueNumber; } }

		[DisplayName("Плательщик")]
		public string Sender { get { return null; } }

		[DisplayName("Дата платежа")]
		public DateTime PaymentDate { get { return DateTime.MinValue; } }

		[DisplayName("Тип платежа")]
        public string PaymentType { get { return null; } }

		[DisplayName("Сумма")]
		public decimal Amount { get { return _component.Amount; } }

		[DisplayName("Код валюты в которой производится расчет")]
        public string CurrencyCode { get { return null; } }
		
		[DisplayName("Комментарий менеджера")]
		public string Comment { get { return _component.Comment; } }

	
		//[DisplayName("Дата создания")]
		//public DateTime CreatedAt { get { return _component.CreatedAt; } }
				
		
		[DisplayName("Описание, основание платежа")]
        public string Description { get { return null; } }
				
		[DisplayName("Внешний номер платежа")]
        public string ExternalNumber { get { return null; } }
				
		[DisplayName("Внесен вручную")]
        public bool IsManual { get { return false; } }
				
		[DisplayName("Разнесен")]
		public bool IsPosted { get { return false; } }
				
		//[DisplayName("Время последнего обновления")]
		//public DateTime LastUpdate { get { return _component.LastUpdate; } }
				


		public PaymentDecorator(Payment component)
		{
			_component = component;
		}
	}
}
