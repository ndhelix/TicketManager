using System;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Protocol.Requests;
using TicketMan.Platform.Protocol.ObjectModel;
using NUnit.Framework;

namespace TicketMan.Platform.Api.Sdk.Connectors
{
    public class Hotels
    {
        private HotelsRestClient CreateRestClient()
        {
            var restClient = new HotelsRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
            restClient.ImpersonationToken = new ImpersonationToken(Config.UserLogin, Config.UserPassword);

            return restClient;
        }


        /// <summary>
        /// Функция поиска отелей
        /// </summary>
        [Test]
        public void SearchHotels()
        {
            var restClient = CreateRestClient();

            var hotelSearchParameters = CreateSearchRequest();

            TourMLDocument searchResult = restClient.GetHotels(hotelSearchParameters);

            var packages = searchResult.Payload as PackagesPayloadElement;

            Assert.NotNull(packages, "Payload of TourMLDocument must have PackagesPayloadElement type.");
        }

        private HotelSearchRequest CreateSearchRequest()
        {
            var hotelSearchParameters = new HotelSearchRequest();

            hotelSearchParameters.CheckInDate = DateTime.Now.AddMonths(6);
            hotelSearchParameters.CheckOutDate = DateTime.Now.AddMonths(6).AddDays(1);
            hotelSearchParameters.CityCode = "3CHA";
            hotelSearchParameters.CountryCode = "TH";
            hotelSearchParameters.Rooms.Add(new RoomSearchParameters { Adult = 1 });

            return hotelSearchParameters;
        }
    }
}
