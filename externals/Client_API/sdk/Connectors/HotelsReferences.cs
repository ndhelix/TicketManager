using System;
using System.Diagnostics;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Protocol.Requests;
using NUnit.Framework;

namespace TicketMan.Platform.Api.Sdk.Connectors
{
    public class HotelsReferences
    {
        private HotelsReferencesRestClient CreateRestClient()
        {
            var restClient = new HotelsReferencesRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
            restClient.ImpersonationToken = new ImpersonationToken(Config.UserLogin, Config.UserPassword);

            return restClient;
        }

        [Test]
        public void GetCities()
        {
            var restClient = CreateRestClient();

            var tourMl = restClient.GetCities();

            foreach (var country in tourMl.References.Countries)
            {
                Trace.WriteLine(String.Format("Id: {0}, IataCode: {1} Name: {2}", country.ID, country.UniformCode, country.Name));
            }
        }
    }
}
