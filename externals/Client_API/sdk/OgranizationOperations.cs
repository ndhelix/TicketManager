using System;
using System.Collections.Generic;
using System.Diagnostics;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel;
using TicketMan.Platform.Protocol.ObjectModel.Contracts;
using NUnit.Framework;

namespace TicketMan.Platform.Api.Sdk
{
    public class OgranizationOperations
    {
        private OrganizationRestClient CreateRestClient()
        {
            var restClient = new OrganizationRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
            restClient.ImpersonationToken = new ImpersonationToken(Config.UserLogin, Config.UserPassword);

            return restClient;
        }


        /// <summary>
        /// Пример получения списка организаций-клиентов текущей компании.
        /// 
        /// Клиенты или покупатели — организации который являются плательщиками по контрактам.
        /// </summary>
        [Test]
        public void GetBuyers()
        {
            var restClient = CreateRestClient();

            IList<OrganizationInfo> buyers = restClient.GetBuyers(ContractType.Sales /*Субагенты по цепочке продаж*/);

            Assert.NotNull(buyers);

            foreach (var organization in buyers)
                Trace.WriteLine(String.Format("Organization '{0} : {1}' loaded as buyer for current.", organization.Code, organization.ShortName));
        }

        /// <summary>
        /// Пример запроса получения субагентств для субагента
        /// </summary>
        [Test]
        public void GetBuyersForSomeOrganization()
        {
            var restClient = CreateRestClient();

            IList<OrganizationInfo> buyers = restClient.GetBuyers(ContractType.Sales, "sputnik" /*Код субагента*/);

            Assert.NotNull(buyers);

            foreach (var organization in buyers)
                Trace.WriteLine(String.Format("Organization '{0} : {1}' loaded as buyer for 'sputnik'.", organization.Code, organization.ShortName));
        }


        /// <summary>
        /// Пример получения списка организаций-поставщиков текущей компании.
        /// 
        /// Поставщики или продавцы — организации который являются получателями денег по контрактам.
        /// </summary>
        [Test]
        public void GetSellers()
        {
            var restClient = CreateRestClient();

            IList<OrganizationInfo> sellers = restClient.GetSellers(ContractType.Sales);

            Assert.NotNull(sellers);

            foreach (var organization in sellers)
                Trace.WriteLine(String.Format("Organization '{0} : {1}' loaded as seller for current.", organization.Code, organization.ShortName));
        }



        /// <summary>
        /// Пример получения структурных подразделений данной организации.
        /// </summary>
        [Test]
        public void GetChildOrganization()
        {
            var restClient = CreateRestClient();

            IList<OrganizationInfo> children = restClient.GetChildOrganizations();

            Assert.NotNull(children);

            foreach (var organization in children)
                Trace.WriteLine(String.Format("Organization '{0} : {1}' loaded as child for current.", organization.Code, organization.ShortName));
        }

        /// <summary>
        /// Пример получения структурных подразделений для субагента.
        /// </summary>
        [Test]
        public void GetChildOrganizationForSomeOrganization()
        {
            var restClient = CreateRestClient();

            IList<OrganizationInfo> children = restClient.GetChildOrganizations("sputnik" /*Код субагента*/);

            Assert.NotNull(children);

            foreach (var organization in children)
                Trace.WriteLine(String.Format("Organization '{0} : {1}' loaded as child for 'sputnik'.", organization.Code, organization.ShortName));
        }

        /// <summary>
        /// Пример загрузки данных у организации организации.
        /// </summary>
        [Test]
        public void LoadOrganization()
        {
            var restClient = CreateRestClient();

            Organization organization = restClient.GetOrganization("7tur" /*Код субагента*/);

            Assert.NotNull(organization);
        }

        /// <summary>
        /// Пример обновления данных у организации организации.
        /// </summary>
        [Test]
        public void UpdateOrganization()
        {
            var restClient = CreateRestClient();

            Organization organization = restClient.GetOrganization("TestTur_aadac4" /*Код субагента*/);

            Assert.NotNull(organization);

            organization.FullName = "ООO «Спутник»";

            //В общем случае у организации Essentials может быть null
            organization.Essentials = new Essentials {Inn = "123456789"};

            organization = restClient.UpdateOrganization(organization);

            Assert.NotNull(organization);
        }

        /// <summary>
        /// Пример создания новой организации.
        /// </summary>
        [Test]
        public void CreateOrganization()
        {
            var restClient = CreateRestClient();

            var organization = new Organization();

            organization.FullName = "OOO «Тестовый Тур»";
            organization.ShortName = "ТестТур";
            organization.Code = "TestTur_" + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6);

            organization.Essentials = new Essentials();
            organization.Essentials.Inn = "1234567890";

            var bankAccount1 = new BankAccount();
            bankAccount1.Code = "account1"; //Идендификатор счета
            bankAccount1.Bik = "12345";
            bankAccount1.AccountNumber = "123457783783783498464";
            bankAccount1.CorrespondingAccountNumber = "19819819181919194194";

            var bankAccount2 = new BankAccount();
            bankAccount2.Code = "account2"; //Идендификатор счета
            bankAccount2.Bik = "12345";
            bankAccount2.AccountNumber = "123457783783783498464";
            bankAccount2.CorrespondingAccountNumber = "19819819181919194194";

            organization.Essentials.BankAccounts.Add(bankAccount1);
            organization.Essentials.BankAccounts.Add(bankAccount2);

            organization.Essentials.DefaultBankAccountCode = "account2"; //Задаем расчетный счет по умолчанию

            //Заведение организаций без контрактов не допускается. Нужен хотябы один.
            var contract = new Contract();

            contract.ContractType = ContractType.Sales;
            contract.ServiceType = "flights";
            contract.CurrencyCode = "Rub";
            contract.Formulas = new List<ContractFormula>();
            contract.Formulas.Add(new ContractFormula
                                      {Description = "Авиабилет", Formula = "[TotalPrice] * 0.98", Number = 0});

            organization = restClient.CreateOrganization(organization, new List<Contract> { contract });

            Assert.NotNull(organization);
        }
    }
}
