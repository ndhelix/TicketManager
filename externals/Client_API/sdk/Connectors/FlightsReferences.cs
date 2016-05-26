using System;
using System.Diagnostics;
using TicketMan.Platform.Api.Shared;
using NUnit.Framework;

namespace TicketMan.Platform.Api.Sdk.Connectors
{
    public class FlightsReferences
    {
        private FlightsReferencesRestClient CreateRestClient()
        {
            var restClient = new FlightsReferencesRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
            restClient.ImpersonationToken = new ImpersonationToken(Config.UserLogin, Config.UserPassword);

            return restClient;
        }

        [Test]
        public void GetCountries()
        {
            var restClient = CreateRestClient();

            var tourMl = restClient.GetCountries();

            foreach (var country in tourMl.References.Countries)
            {
                Trace.WriteLine(String.Format("Id: {0}, IataCode: {1} Name: {2}", country.ID, country.UniformCode, country.Name));
            }
        }

        [Test]
        public void GetCities()
        {
            var restClient = CreateRestClient();

            var tourMl = restClient.GetCities();

            foreach (var city in tourMl.References.Cities)
            {
                Trace.WriteLine(String.Format("Id: {0}, IataCode: {1} Name: {2}", city.ID, city.UniformCode, city.Name));
            }
        }

        [Test]
        public void GetAirports()
        {
            var restClient = CreateRestClient();

            var tourMl = restClient.GetAirports();

            foreach (var airport in tourMl.References.Airports)
            {
                Trace.WriteLine(String.Format("Id: {0}, IataCode: {1} Name: {2}", airport.ID, airport.UniformCode, airport.Name));
            }
        }

        [Test]
        public void GetAirlines()
        {
            var restClient = CreateRestClient();

            var tourMl = restClient.GetAirlines();

            foreach (var airline in tourMl.References.Airlines)
            {
                Trace.WriteLine(String.Format("Id: {0}, IataCode: {1} Name: {2}", airline.ID, airline.UniformCode, airline.Name));
            }
        }
    }
}
