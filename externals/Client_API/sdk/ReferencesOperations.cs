using System;
using System.Collections.Generic;
using System.Diagnostics;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel;
using NUnit.Framework;

namespace TicketMan.Platform.Api.Sdk
{
    /// <summary>
    /// Примеры работы с отчетами
    /// </summary>
    public class ReferencesOperations
    {
        private ReferencesRestClient CreateRestClient()
        {
            var restClient = new ReferencesRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
            restClient.ImpersonationToken = new ImpersonationToken(Config.UserLogin, Config.UserPassword);

            return restClient;
        }


        /// <summary>
        /// Пример получения списка услуг
        /// </summary>
        [Test]
        public void CreateOutInvoice()
        {
            ReferencesRestClient restClient = CreateRestClient();

            List<ServiceType> serviceTypes = restClient.GetServiceTypes();

            Assert.NotNull(serviceTypes);

            foreach (var serviceType in serviceTypes)
            {
                Trace.WriteLine(String.Format("На сервере действует услуга '{1}' с кодом '{0}'.", serviceType.Code, serviceType.Name));
            }
        }
    }
}
