using System;
using System.Collections.Generic;
using System.Diagnostics;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel;
using NUnit.Framework;

namespace TicketMan.Platform.Api.Sdk
{
    class ConnectorsConfigurationOperations
    {
        private ConnectorsConfigurationRestClient CreateRestClient()
        {
            var restClient = new ConnectorsConfigurationRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
            restClient.ImpersonationToken = new ImpersonationToken(Config.UserLogin, Config.UserPassword);

            return restClient;
        }


        /// <summary>
        /// Пример получения значений настроек для коннектора.
        /// </summary>
        [Test]
        public void GetConnectorsConfiguration()
        {
            var restClient = CreateRestClient();

            ConnectorsConfiguration connectorsConfiguration = restClient.GetConnectorsConfiguration("TicketMan" /*Код организации*/, "flights" /*serviceType*/);

            Assert.NotNull(connectorsConfiguration);

            foreach (var variable in connectorsConfiguration.Variables)
                Trace.WriteLine(String.Format("Variable '{0}' with value '{1}' was loaded.", variable.Name, variable.Value));
        }


        /// <summary>
        /// Пример сохранения значений настроек для коннектора.
        /// </summary>
        [Test]
        public void SetConnectorsConfiguration()
        {
            var restClient = CreateRestClient();

            var connectorsConfiguration = new ConnectorsConfiguration
                                              {Variables = new List<ConnectorConfigurationVariable>()};

            connectorsConfiguration.Variables.Add(new ConnectorConfigurationVariable
                                                      {
                                                          Name = "FlightHAP",
                                                          ServiceType = "flights",
                                                          OrganizationCode = "sputnik",
                                                         // SiteSlug = "sputnik",
                                                          Value = "TestHap"
                                                      });

            restClient.SetConnectorsConfiguration(connectorsConfiguration);

            /*Если мы попали сюда, все прошло без эксепшена*/
            Trace.WriteLine("Все сохранено.");
        }


        /// <summary>
        /// Пример удаления значений настроек для коннектора.
        /// </summary>
        [Test]
        public void DeleteConnectorsConfiguration()
        {
            var restClient = CreateRestClient();

            var connectorsConfiguration = new ConnectorsConfiguration
                                              {Variables = new List<ConnectorConfigurationVariable>()};

            connectorsConfiguration.Variables.Add(new ConnectorConfigurationVariable
                                                      {
                                                          Name = "FlightHAP",
                                                          ServiceType = "flights",
                                                          OrganizationCode = "sputnik",
                                                          //SiteSlug = "TicketMan",
                                                          Value = null //Удалить переменную
                                                      });

            restClient.SetConnectorsConfiguration(connectorsConfiguration);

            /*Если мы попали сюда, все прошло без эксепшена*/
            Trace.WriteLine("Все сохранено.");
        }
    }
}
