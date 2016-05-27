using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Protocol.Requests.Tours;
using TicketMan.Platform.Protocol.ObjectModel;
using TicketMan.Platform.Protocol.ObjectModel.Contracts;
using TicketMan.Platform.Protocol.ObjectModel.Packages;
using TicketMan.Platform.Protocol.ObjectModel.References;
using NUnit.Framework;
using Vendor = TicketMan.Platform.Protocol.ObjectModel.References.Vendor;

namespace TicketMan.Platform.Api.Sdk.Connectors
{
    public class Tours
    {
        private ToursRestClient CreateRestClient()
        {
            var restClient = new ToursRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
            //restClient.ImpersonationToken = new ImpersonationToken(Config.UserLogin, Config.UserPassword);

            return restClient;
        }

        [Test]
        public void UpdateReservation()
        {
            var vendor = new Vendor(57924, "Pegas Touristik");

            var package = new Package()
                              {
                                  ID = 4000021786519483,
                                  VendorID = vendor.ID,
                                  BaseDate = new Date(2012, 7, 19),
                                  PlaceAllocations = {new PlaceAllocation(AgeType.Adult, 2)}
                              };

            var reservationTourMLDocument = new TourMLDocument();
            
            reservationTourMLDocument.CreateReservationsPayload(package);

            reservationTourMLDocument.References.Vendors.Add(vendor);
            
            using (var client = CreateRestClient())
            {
                var result = client.UpdateReservation(reservationTourMLDocument);

                Assert.NotNull(result);

                Assert.IsTrue(result.IsReservationsPayload());
            }
        }
    }
}
