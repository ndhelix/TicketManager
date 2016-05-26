using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Payments;
using TicketMan.Platform.Api.Shared.Protocol.Requests;
using NUnit.Framework;

namespace TicketMan.Platform.Api.Sdk
{
    /// <summary>
    /// Примеры работы с платежными извещениями
    /// </summary>
    public class PaymentReportOperations
    {
        private PaymentReportsRestClient CreateRestClient()
        {
            var restClient = new PaymentReportsRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
            restClient.ImpersonationToken = new ImpersonationToken(Config.UserLogin, Config.UserPassword);

            return restClient;
        }


        #region Функции для платежного шлюза

        /// <summary>
        /// Пример получения платежной информации по заявке перед ее оплатой.
        /// </summary>
        [Test]
        public void GetPaymentReportInfo()
        {
            var restClient = CreateRestClient();

            const string orderNumber = "order_test";


            //Для получение сведений для оплаты мы передаем номер путевки, тип плательщика и список платежных систем по которым планируется оплата. 
            var paymentInfo = restClient.GetPaymentReportInfo(orderNumber /*номер заявки*/, PayerLegalStatus.LegalParty, new List<string> { "Minb", "Rapida", "Promsvazbank" });

            Assert.NotNull(paymentInfo);

            Assert.AreEqual(orderNumber, paymentInfo.UniqueNumber);

            Trace.WriteLine(String.Format("Цены для заявки {0}.", orderNumber));

            foreach (var priceInfo in paymentInfo.OrderPaymentPrices)
            {
                Trace.WriteLine(String.Format("Для системы {0}: {1} {2}.", priceInfo.PaymentSystemCode, priceInfo.Price.Value, priceInfo.PaymentSystemCode));
            }
        }

        /// <summary>
        /// Пример создания извещения об оплате в системе
        /// </summary>
        [Test]
        public void CreatePaymentReport()
        {
            var restClient = CreateRestClient();

            var paymentReport = new PaymentReport();

            paymentReport.PaymentAmount = (decimal)100.00;
            paymentReport.CurrencyCode = "Rub";

            paymentReport.OrderUniqueNumber = "order_test";

            paymentReport.PayerLegalStatus = PayerLegalStatus.NaturalParty;

            paymentReport.PaymentSystem = new PartyInfo();
            paymentReport.PaymentSystem.OrganizationCode = "Minb";
            paymentReport.PaymentSystemUniqueNumber = "2134634643";
            
            //paymentReport.CreatedAt — будет перезаписано на сервере

            //paymentReport.Beneficiar — опционально,
            //                           устанавливается только если получатель не владелец сайта, от которого происходит подключение.
            //                           Например, если это его структурная единица.

            //paymentReport.Payer — необязательная информация о плательщике. 
            //                      Плательщиком считается либо владелец заявки (при PayerLegalStatus = NaturalParty), либо конечный продавец (при PayerLegalStatus = LegalParty)


            paymentReport.Comment = "Дополнительная информация по платежу."; //Не обязательно

            //Возвращает новый объект, который содержит обновленные данные полей.
            paymentReport = restClient.CreatePaymentReport(paymentReport);

            Assert.NotNull(paymentReport);

            Assert.NotNull(paymentReport.UniqueNumber); //Новый уникальный номер платежа
        }

        #endregion


        #region Функции для работы сот списком заявок

        /// <summary>
        /// Пример получения всех платежных извещений для конкретной заявки
        /// </summary>
        [Test]
        public void GetPaymentReportsForOrder()
        {
            var restClient = CreateRestClient();

            var paymentReports = restClient.GetPaymentReports("order_test" /*номер заявки*/);

            Assert.NotNull(paymentReports);

            foreach (var paymentReport in paymentReports)
            {
                Assert.Greater(paymentReport.PaymentAmount, 0); //Сумма платежа

                Trace.WriteLine(String.Format("Оплата №{0} на сумму {1} {2}. Оплачено через {3}", paymentReport.UniqueNumber, paymentReport.PaymentAmount, paymentReport.CurrencyCode, paymentReport.PaymentSystem.Name));
            }
        }


        /// <summary>
        /// Пример получения всех платежных извещений c учетом фильтров
        /// </summary>
        [Test]
        public void GetPaymentReports()
        {
            var restClient = CreateRestClient();

            var paymentReportsRequest = new PaymentReportsRequest();

            paymentReportsRequest.PageNumber = 0; //Первая страница
            paymentReportsRequest.PageSize = 0; //Два платежа на страницу
            paymentReportsRequest.CreatedOnFrom = DateTime.Now.AddDays(-30); //Платежи за последние 30 дней

            //paymentReportsRequest.PaymentSystemCodes — содержит коды платежных систем, если пустой, то фильтрация по ним не производится.

            var paymentReports = restClient.GetPaymentReportsInfo(paymentReportsRequest);

            Assert.NotNull(paymentReports);

            foreach (var paymentReport in paymentReports)
            {
                Assert.Greater(paymentReport.PaymentAmount, 0); //Сумма платежа

                Assert.Greater(paymentReport.RecivingAmount, 0); //Сумма зачисленная на счет получателя

                Assert.Greater(paymentReport.CommissionAmount, 0); //Сумма реальной комиссии платежного агента

                Assert.NotNull(paymentReport.PaymentSystem); //Код платежной системы

                Assert.NotNull(paymentReport.Payer.Name); //Имя плаительщика

                Assert.NotNull(paymentReport.Beneficiar.Name); //Название организаци-получателя
            }
        }

        #endregion
    }
}
