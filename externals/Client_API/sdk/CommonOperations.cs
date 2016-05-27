using System;
using System.Diagnostics;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Exceptions;
using NUnit.Framework;

namespace TicketMan.Platform.Api.Sdk
{
    public class CommonOperations
    {
        private OrdersRestClient CreateRestClient()
        {
            var restClient = new OrdersRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
            restClient.ImpersonationToken = new ImpersonationToken(Config.UserLogin, Config.UserPassword);

            return restClient;
        }

        /// <summary>
        /// Пример обработки ошибок на примере OrdersRestClient
        /// </summary>
        [Test]
        public void HandlingErrors()
        {
            var restClient = CreateRestClient();

            try
            {
                var order = restClient.GetOrder("order10");

                Assert.NotNull(order);
            }
            catch (LogicalApiException e)
            {
                Trace.WriteLine(String.Format("Получение заявки не удалось. Код: {0}. Сообщение: {1}", e.Code, e.Message));
                return;
            }
            catch (AuthorizationApiException e)
            {
                Trace.WriteLine(String.Format("Получение заявки не удалось. Не хватает разрешения '{0}'. Сообщение сервера: '{1}'", e.Permission, e.Message));
                return;
            }
            catch (ArgumentApiException e)
            {
                Trace.WriteLine(String.Format("Получение заявки не удалось. В запросе неверно указан аргумент '{0}'. Сообщение сервера: '{1}'", e.ArgumentName, e.Message));
                return;
            }
            catch (SystemApiException e)
            {
                Trace.WriteLine(String.Format("Получение заявки не удалось. Критическая ошибка сервера: '{0}'", e.Message));
                return;
            }
            
            //Остальные ошибки вызванные не на уровне сервера, вызывают системные исключения.

            Trace.WriteLine("Получение заявки выполнено успешно");
        }
    }
}
