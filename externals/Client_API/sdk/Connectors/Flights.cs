using System;
using System.Collections.Generic;
using System.Linq;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Protocol.Requests;
using TicketMan.Platform.Protocol.ObjectModel;
using TicketMan.Platform.Protocol.ObjectModel.Orders;
using TicketMan.Platform.Protocol.ObjectModel.Reservations;
using NUnit.Framework;

namespace TicketMan.Platform.Api.Sdk.Connectors
{
    public class Flights
    {
        private FlightsRestClient CreateRestClient()
        {
            var restClient = new FlightsRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
            restClient.ImpersonationToken = new ImpersonationToken(Config.UserLogin, Config.UserPassword);

            return restClient;
        }


        /// <summary>
        /// Импортирует в систему заявку по ее PNR
        /// </summary>
        [Test]
        public void ImportOrder()
        {
            var flightsRestClient = CreateRestClient();

            const string requiredVendorUniqueNumber = "WVF2TM";

            var request = new ImportOrderRequest
                              {
                                  VendorUniqueNumber = requiredVendorUniqueNumber,
                                  Owner = new ImportOrderRequest.User { Login = "avia@invest-marvik.ru", SiteSlug = "invest-marvik" }
                              };

            TourMLDocument tourMLDocument = flightsRestClient.ImportOrder(request);

            Assert.NotNull(tourMLDocument);

            var ordersPayload = tourMLDocument.GetOrdersPayload();

            Assert.NotNull(ordersPayload);

            var vendorUniqueNumber = ordersPayload.Orders.First().VendorUniqueNumber;

            Assert.AreEqual(requiredVendorUniqueNumber, vendorUniqueNumber);
        }

        /// <summary>
        /// Функция поиска перелетов
        /// </summary>
        [Test]
        public void SearchFlights()
        {
            var flightsRestClient = CreateRestClient();

            var flightSearchRequest = new FlightSearchRequest();

            TourMLDocument searchResult = flightsRestClient.GetFlights(flightSearchRequest);

            var packages = searchResult.Payload as PackagesPayloadElement;

            Assert.NotNull(packages, "Payload of TourMLDocument must have PackagesPayloadElement type.");
        }

        /// <summary>
        /// Функция бронирования перелетов
        /// </summary>
        [Test]
        public void BokingFlights()
        {
            var flightsRestClient = CreateRestClient();

            var bookingRequestPayload = new ReservationsPayloadElement();

            bookingRequestPayload.Clients = new List<Client> { CreateClient() };

            bookingRequestPayload.Reservations = new List<Reservation> { CreateReservation() };

            flightsRestClient.CreateOrder(new TourMLDocument{Payload = bookingRequestPayload});
        }


        private Client CreateClient()
        {
            var client = new Client();

            client.ID = 1;

            client.FirstName = new BilingualName(null /*russian*/, "Ivan");
            client.LastName = new BilingualName(null /*russian*/, "Petrov");

            client.Sex = Sex.Male;
            client.DateOfBirth = DateTime.Parse("1976.01.06");
            client.Citizenship = new BilingualName("Россия", "Russia");
            client.CitizenshipCountryID = 1;

            client.Passports = new List<Passport>
                                   {
                                       new Passport(
                                           PassportType.International,
                                           "123456547" /*passportNumber*/,
                                           null /*series*/,
                                           null /*issuedOn*/,
                                           DateTime.Parse("2015.01.06") /*expiredBy*/,
                                           null /*issuedBy*/)
                                   };

            client.Contacts = new Contacts("user@client.com", new Phone(PhoneType.Mobile, "+7 916 085 45 65"));

            return client;
        }

        private Reservation CreateReservation()
        {
            var reservation = new Reservation();

            reservation.Payer = new Payer();
            reservation.Payer.ClientID = 1; 

            return reservation;
        }
    }
}
