using System;
using System.Collections.Generic;
using System.Diagnostics;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel;
using NUnit.Framework;

namespace TicketMan.Platform.Api.Sdk
{
    public class SiteOperations
    {
        private SiteRestClient CreateRestClient()
        {
            var restClient = new SiteRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
            restClient.ImpersonationToken = new ImpersonationToken(Config.UserLogin, Config.UserPassword);

            return restClient;
        }


        /// <summary>
        /// Пример получения описания сайта по его SiteSlug.
        /// </summary>
        [Test]
        public void GetCurrentSite()
        {
            var restClient = CreateRestClient();

            Site site = restClient.GetCurrentSite();

            Assert.NotNull(site);
            Assert.AreEqual(Config.SiteSlug, site.SiteSlug);

            Trace.WriteLine(String.Format("Site '{0} : {1}' was loaded as current site.", site.SiteSlug, site.Name));
        }

        /// <summary>
        /// Пример получения списка сайтов одной компании.
        /// </summary>
        [Test]
        public void GetSites()
        {
            var restClient = CreateRestClient();

            IList<Site> sites = restClient.GetSites("TicketMan" /*Код организации*/);

            Assert.NotNull(sites);

            foreach (var site in sites)
                Trace.WriteLine(String.Format("Site '{0} : {1}' was loaded.", site.SiteSlug, site.Name));
        }


        /// <summary>
        /// Пример получения описания сайта по его SiteSlug.
        /// </summary>
        [Test]
        public void GetSite()
        {
            var restClient = CreateRestClient();

            Site site = restClient.GetSite("TicketMan" /*Код сайта*/);

            Assert.NotNull(site);
            Assert.AreEqual("TicketMan", site.SiteSlug);

            Trace.WriteLine(String.Format("Site '{0} : {1}' was loaded.", site.SiteSlug, site.Name));
        }

        /// <summary>
        /// Пример создания сайта
        /// </summary>
        [Test]
        public void CreateSite()
        {
            var restClient = CreateRestClient();

            var site = new Site();

            site.SiteSlug = "newTestSite";
            site.OrganizationCode = "TicketMan";
            site.Name = "test.TicketMan.ru";
            site.IsActive = true;

            //site.ApiKey - будет сгенерирован на сайте, задавать тут смысла нет.

            site = restClient.CreateSite(site);

            Assert.NotNull(site);
            Assert.AreEqual("newTestSite", site.SiteSlug);
            Assert.IsNotEmpty(site.ApiKey);

            Trace.WriteLine(String.Format("Site '{0} : {1}' was created.", site.SiteSlug, site.Name));
            Trace.WriteLine(String.Format("ApiKey: {0}", site.ApiKey));
        }


        /// <summary>
        /// Пример редактирвоания сайта
        /// </summary>
        [Test]
        public void UpdateSite()
        {
            var restClient = CreateRestClient();

            Site site = restClient.GetSite("TicketMan");

            /*По сути сейчас для редактирования открыто только два поля.*/
            site.Name = "TicketMan.ru";
            site.IsActive = true;
            
            site = restClient.UpdateSite(site);

            Assert.NotNull(site);
            Assert.AreEqual("TicketMan.ru", site.Name);

            Trace.WriteLine(String.Format("Site '{0} : {1}' was updated.", site.SiteSlug, site.Name));
        }
    }
}
