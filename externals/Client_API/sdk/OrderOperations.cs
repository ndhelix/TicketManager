using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Exceptions;
using TicketMan.Platform.Protocol.ObjectModel;
using TicketMan.Platform.Protocol.ObjectModel.Orders;
using NUnit.Framework;

namespace TicketMan.Platform.Api.Sdk
{
    public class OrderOperations
    {
        private OrdersRestClient CreateRestClient()
        {
            var restClient = new OrdersRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
            restClient.ImpersonationToken = new ImpersonationToken(Config.UserLogin, Config.UserPassword);

            return restClient;
        }


        /// <summary>
        /// Пример получения списка заявок из кабинета.
        /// 
        /// Список возвращается в контексте текущего пользователя.
        /// </summary>
        [Test]
        public void GetOrders()
        {
            var restClient = CreateRestClient();

            var ordersInfoRequest = new OrdersInfoRequest();

            ordersInfoRequest.PageSize = 10;
            ordersInfoRequest.Statuses = new List<OrderStatus> { OrderStatus.Pending, OrderStatus.Confirmed};
            ordersInfoRequest.CreatedOnFrom = DateTime.Parse("2011.08.01");

            var ordersInfo = restClient.GetOrdersInfo(ordersInfoRequest);

            Assert.NotNull(ordersInfo);

            var ordersInfoPayload = ordersInfo.Payload as OrdersInfoPayloadElement;

            Assert.NotNull(ordersInfoPayload);

            var orders = ordersInfoPayload.OrdersInfo;

            Assert.AreEqual(orders.Count, 10);
        }

        /// <summary>
        /// Получение описания конкретной заявки 
        /// </summary>
        [Test]
        public void GetOrder()
        {
            var restClient = CreateRestClient();

            var order = restClient.GetOrder("order1");

            Assert.NotNull(order);

            var ordersPayload = order.Payload as OrdersPayloadElement;

            Assert.NotNull(ordersPayload);

            Assert.AreEqual("order1", ordersPayload.Orders.First().UniqueNumber);
        }

        /// <summary>
        /// Пример вызова обновления заявки в системе вендора
        /// </summary>
        [Test]
        public void UpdateOrder()
        {
            var restClient = CreateRestClient();

            try
            {
                restClient.UpdateOrder("E2E17", OrderRefreshBehavior.ForceRefresh);
            } catch (Exception e)
            {
                Trace.WriteLine("Обновление не удалось. Причина: " + e.Message);
                return;
            }

            Trace.WriteLine("Обновление заявки выполнено успешно");
        }

        /// <summary>
        /// Пример вызова отмены заявки в системе вендора
        /// </summary>
        [Test]
        public void CancelOrder()
        {
            var restClient = CreateRestClient();

            try
            {
                restClient.CancelOrder("order1");
            }
            catch (LogicalApiException e)
            {
                Trace.WriteLine(String.Format("Отмена не удалось. Код: {0}. Сообщение: {1}", e.Code, e.Message));
                return;
            }

            Trace.WriteLine("Отмена заявки выполнена успешно");
        }

        /// <summary>
        /// Пример вызова выписки заявки в системе вендора
        /// </summary>
        [Test]
        public void IssueOrder()
        {
            var restClient = CreateRestClient();

            try
            {
                restClient.IssueOrder("BD40D");
            }
            catch (LogicalApiException e)
            {
                Trace.WriteLine(String.Format("Выписка не удалось. Код: {0}. Сообщение: {1}", e.Code, e.Message));
                return;
            }

            Trace.WriteLine("Выписка заявки выполнена успешно");
        }
    }
}
