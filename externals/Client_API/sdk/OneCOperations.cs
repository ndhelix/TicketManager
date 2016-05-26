using System;
using System.Linq;
using TicketMan.Platform.Api.Shared;
using NUnit.Framework;

namespace TicketMan.Platform.Api.Sdk
{
    public class OneCOperations
    {
		private OneCRestClient CreateRestClient()
        {
            var restClient = new OneCRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
            restClient.ImpersonationToken = new ImpersonationToken(Config.UserLogin, Config.UserPassword);

            return restClient;
        }




		/// <summary>
		/// Пример получения списка заявок для 1С.
		/// </summary>
		[Test]
		public void GetAccountingData()
		{
			var restClient = CreateRestClient();

			var accountingData = restClient.GetAccountingData(DateTime.Parse("2012.01.10"));

			Assert.NotNull(accountingData);
			Assert.AreNotEqual(0, accountingData.Orders.Count());
			Assert.AreNotEqual(0, accountingData.Contragents.Count());
		}


	}
}
