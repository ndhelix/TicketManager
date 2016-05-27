using System.Diagnostics;
using System.IO;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Protocol.ObjectModel.Orders;
using NUnit.Framework;

namespace TicketMan.Platform.Api.Sdk
{
    public class OrderDocumentsOperations
    {
        private OrdersDocumentsRestClient CreateRestClient()
        {
            var restClient = new OrdersDocumentsRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
            restClient.ImpersonationToken = new ImpersonationToken(Config.UserLogin, Config.UserPassword);

            return restClient;
        }


        /// <summary>
        /// Пример получения списка заявок из кабинета.
        /// 
        /// Список возвращается в контексте текущего пользователя.
        /// </summary>
        [Test]
        public void GetOrderDocuments()
        {
            var restClient = CreateRestClient();

            OrderDocument orderDocument = restClient.GetOrderDocument("E2E17" /*Order Number*/, "E2EF4" /*Document Number*/);

            Assert.NotNull(orderDocument);

            //Сохраняем присланные байты в файл
            string filePath = Path.Combine(Path.GetTempPath(), orderDocument.Name /*Это имя вполне подойдет для названия файла*/);
            File.WriteAllBytes(filePath, orderDocument.Content);

            //Запускаем файл в связанном приложении
            Process.Start(new ProcessStartInfo { FileName = filePath, UseShellExecute = true });
        }

        /// <summary>
        /// Пример рассылки выписанных документов пользователю.
        /// </summary>
        [Test]
        public void SendingIssuedDocuments()
        {
            var restClient = CreateRestClient();

            restClient.SendIssuedDocuments("E2E17" /*Order Number*/);
        }
    }
}
