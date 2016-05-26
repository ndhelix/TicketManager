using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel;
using TicketMan.Platform.Protocol.ObjectModel.Contracts;
using NUnit.Framework;

namespace TicketMan.Platform.Api.Sdk
{
    class ContractOperations
    {
        private ContractsRestClient CreateRestClient()
        {
            var restClient = new ContractsRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
            restClient.ImpersonationToken = new ImpersonationToken(Config.UserLogin, Config.UserPassword);

            return restClient;
        }

        [Test]
        public void GetContracts()
        {
            var restClient = CreateRestClient();

            IList<Contract> contracts = restClient.GetContracts("sputnik" /*Код организации*/);

            Assert.NotNull(contracts);

            var saleContracts = contracts.Where(contract => contract.ContractType == ContractType.Sales);
            var attractClientContracts = contracts.Where(contract => contract.ContractType == ContractType.AttractClient);

            foreach (var contract in saleContracts)
                Trace.WriteLine(String.Format("Contract '{0}' has sale type.", contract.UniqueNumber));

            foreach (var contract in attractClientContracts)
                Trace.WriteLine(String.Format("Contract '{0}' has attract client type.", contract.UniqueNumber));
        }


        [Test]
        public void GetContract()
        {
            var restClient = CreateRestClient();

            Contract contract = restClient.GetContract("2109197");

            Assert.NotNull(contract);

            Trace.WriteLine(String.Format("Contract '{0}' has been loaded. It has '{1}' as Buyer Party id and '{2}' as Seller Party Id.", contract.UniqueNumber, contract.BuyerPartyId, contract.SellerPartyId));
        }

        [Test]
        public void CreateContract()
        {
            var restClient = CreateRestClient();

            var contract = new Contract();

            contract.BuyerPartyId = 70504; //Велка
            contract.SellerPartyId =  70505; //Спутник

            contract.ContractType = ContractType.AttractClient;
            contract.CurrencyCode = "Rub";

            contract.IsActive = true;

            contract.ServiceType = "flights";

            var formula1 = new ContractFormula {Description = "Авиабилеты", Formula = "[TotalPrice] * 0.98", Number = 0};
            var formula2 = new ContractFormula
                               {Description = "Сервисный сбор", Formula = "-[ServiceCharges]", Number = 1};

            contract.Formulas = new List<ContractFormula> { formula1, formula2 };

            contract = restClient.CreateContract(contract);

            Assert.NotNull(contract);

            Trace.WriteLine(String.Format("New contract unique number is '{0}'.", contract.UniqueNumber));
        }


        [Test]
        public void UpdateContract()
        {
            var restClient = CreateRestClient();

            Contract contract = restClient.GetContract("140");

            Assert.NotNull(contract);

            contract.Formulas = new List<ContractFormula>
                                    {
                                        new ContractFormula
                                            {
                                                Description = "{aragementDescription}",
                                                Formula = "[totalPrice]",
                                                Number = 1
                                            },
                                        new ContractFormula
                                            {Description = "Комиссия", Formula = "- 0.05 * [totalPrice]", Number = 2}
                                    };

            contract = restClient.UpdateContract(contract);

            Assert.NotNull(contract);

            Trace.WriteLine(String.Format("Last update contract was at '{0}'.", contract.LastUpdate));
        }



        [Test]
        public void GetPriceRoawTypes()
        {
            var restClient = CreateRestClient();

            List<PriceRowType> priceRowTypes = restClient.GetPriceRowTypes();

            Assert.NotNull(priceRowTypes);

            foreach (var priceRowType in priceRowTypes)
            {
                Trace.WriteLine(String.Format("Тип формулы: {0}; Код; {1}; Описание: {2}", priceRowType.Code, priceRowType.Name, priceRowType.Description));
            }
        }
    }
}
