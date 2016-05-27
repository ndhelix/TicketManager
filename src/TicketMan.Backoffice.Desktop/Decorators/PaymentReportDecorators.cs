using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Payments;
using System.ComponentModel;
using TicketMan.Backoffice.Desktop.Core;

namespace TicketMan.Backoffice.Desktop.Decorators
{
	public class PaymentReportInfoDecorator 
	{
		protected  PaymentReportInfo _paymentReportInfo;
		public PaymentReportInfoDecorator(PaymentReportInfo component)
		{
			this._paymentReportInfo = component;
		}

		[DisplayName("Получатель")]
		public string Beneficiar { get { return _paymentReportInfo.Beneficiar.Name; } }

		[DisplayName("Плательщик")]
		public string Payer { get { return _paymentReportInfo.Payer.Name; } }

		/// <summary>
		///     Возвращает или устанавливает дату создания платежа.
		/// </summary>
		[DisplayName("Дата создания")]
		public DateTime CreatedAt { get { return _paymentReportInfo.CreatedAt; } }

        [DisplayName("Сумма")]
        public decimal PaymentAmount { get { return Math.Round(_paymentReportInfo.PaymentAmount, 2); } }

        [DisplayName("Получено")]
        public decimal ReceivedAmount { get { return Math.Round(_paymentReportInfo.RecivingAmount, 2); } }

        /// <summary>
		///     Возвращает или устанавливает идентификатор валюты, в которой производится
		///     платеж.
		/// </summary>
		[DisplayName("Валюта")]
		public string CurrencyCode { get { return _paymentReportInfo.CurrencyCode; } }
		/// <summary>
		///     Возвращает или устанавливает номер заявки, которая оплачивается текущим платежом.
		///
		/// Remarks:
		///     См. TicketMan.Platform.Protocol.ObjectModel.Orders.Order.UniqueNumber.
		/// </summary>
		[DisplayName("Номер заявки")]
		public string OrderUniqueNumber { get { return _paymentReportInfo.OrderUniqueNumber; } }
		
		/// <summary>
		///     Возвращает или устанавливает код платежной системы.
		/// </summary>
		//[DisplayName("Код платежной системы")]
		//public string PaymentSystemUniformCode { get { return _component.PaymentSystemUniformCode; } }
		/// <summary>
		///     Возвращает или устанавливает уникальный номер платежа в пределах системы
		///     платежной системы.
		/// </summary>
		[DisplayName("Номер платежа в пределах системы")]
		public string PaymentSystemUniqueNumber { get { return _paymentReportInfo.PaymentSystemUniqueNumber; } }
		/// <summary>
		///     Возвращает или устанавливает уникальный нормер платежа в пределах TicketMan
		///     Platform.
		/// </summary>
		[DisplayName("Номер платежа в пределах TicketMan")]
		public string UniqueNumber { get { return _paymentReportInfo.UniqueNumber; } }

	}

	public class PaymentReportDecorator : PaymentReportInfoDecorator
	{
		private readonly PaymentReport _paymentReport;
		public PaymentReportDecorator(PaymentReport paymentReport):base(paymentReport)
		{
//			this._paymentReport = paymentReport;
			this._paymentReportInfo = this._paymentReport = paymentReport;
			//base.
		}

		[DisplayName("Комментарий")]
		public string Comment { get { return _paymentReport.Comment; } }


		[DisplayName("Система")]
		public string PaymentSystem { get { return _paymentReport.PaymentSystem.Name; } }

		[DisplayName("Тип")]
		public string Type { get { return _paymentReport.Type.ToString(); } }

		/// <summary>
		///     Возвращает или устанавливает юридический статус плательщика.
		/// </summary>
		[DisplayName("Юридический статус плательщика")]
		public string PayerLegalStatus { get { return EnumTranslator.Translate("PayerLegalStatus", _paymentReportInfo.PayerLegalStatus.ToString()); } }

		/// <summary>
		///     Возвращает или устанавливает идентификатор контрагента-получателя платежа.
		/// </summary>
		[DisplayName("Получатель")]
		public long? BeneficiaryPartyID { get { return _paymentReportInfo.Beneficiar.PartyId; } }

		/// <summary>
		///     Возвращает или устанавливает идентификатор контрагента-плательщика.
		///
		/// Remarks:
		///     Если значение TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Payments.PaymentReportInfo.PayerPartyID
		///     равно null, за плательщика принимается покупатель заявки.
		/// </summary>
		[DisplayName("Идентификатор контрагента")]
		public long? PayerPartyID { get { return _paymentReportInfo.Payer.PartyId; } }

	}
}
