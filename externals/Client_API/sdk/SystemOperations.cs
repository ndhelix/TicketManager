using System;
using System.Diagnostics;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Systems;
using NUnit.Framework;

namespace TicketMan.Platform.Api.Sdk
{
    public class SystemOperations
    {
        private SystemRestClient CreateRestClient()
        {
            var restClient = new SystemRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
            restClient.ImpersonationToken = new ImpersonationToken(Config.UserLogin, Config.UserPassword);

            return restClient;
        }

        /// <summary>
        /// Пример получения информации о сервере.
        /// </summary>
        [Test]
        public void GetSystemInfo()
        {
            var restClient = CreateRestClient();

            ServerSystemInfo serverSystemInfo = restClient.GetServerSystemInfo();

            Trace.WriteLine(String.Format("Полное название сервера: {0}", serverSystemInfo.FullProductName));
            Trace.WriteLine(String.Format("Время сборки: {0}", serverSystemInfo.BuildDate));
            Trace.WriteLine(String.Format("Версия: {0}", serverSystemInfo.Version));

            Trace.WriteLine("В данный момент на сервере подключены следующие коннекторы:");
            foreach (var connectorInfo in serverSystemInfo.ConnectorsInfo)
            {
                Trace.WriteLine(String.Format("Коннектор: {0}, версия: {1}", connectorInfo.ServiceTypeCode, connectorInfo.Version));
            }
        }

        /// <summary>
        /// Получение текущего времени сервера.
        /// </summary>
        [Test]
        public void GetSystemTyme()
        {
            var restClient = CreateRestClient();

            DateTime serverTime = restClient.GetServerTime();

            Trace.WriteLine(String.Format("Время на севрере: {0}", serverTime));
        }
    }
}
