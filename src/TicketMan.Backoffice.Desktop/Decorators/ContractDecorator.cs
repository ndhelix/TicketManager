using System;
using System.Collections.Generic;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel;
using TicketMan.Platform.Protocol.ObjectModel.Contracts;
using System.ComponentModel;
using TicketMan.Platform.Api.Shared;

namespace TicketMan.Backoffice.Desktop.Decorators
{
	public class ContractDecorator
	{
		private readonly Contract _component;

		[DisplayName("Идентификатор контрагента покупателя")]
		public long BuyerPartyId { get { return _component.BuyerPartyId; } }

		[DisplayName("Тип контракта")]
		public ContractType ContractType { get { return _component.ContractType; } }

		[DisplayName("Внешний номер контракта")]
		public string ExternalNumber { get { return _component.ExternalNumber; } }

		private List<ContractFormulaDecorator> _formulas;
		[DisplayName("Формулы контракта")]
		public List<ContractFormulaDecorator> Formulas
		{
			get
			{
				return _formulas ?? (_formulas = _component.Formulas != null
												? _component.Formulas.ConvertAll(x => new ContractFormulaDecorator(x))
												: null);
			}
		}

		[DisplayName("Активность контракта в данный момент")]
		public bool IsActive { get { return _component.IsActive; } }

		[DisplayName("Время последнего обновления контракта")]
		public DateTime LastUpdate { get { return _component.LastUpdate; } }

		[DisplayName("Код банковского счета")]
		public string SellerBankAccountCode { get { return _component.SellerBankAccountCode; } }

		//[DisplayName("Банковский счет продавца")]
		//public BankAccount SellerBankAccount { get
		//{
		//  var restClient = (OrganizationRestClient)DataProcessor.GetRestClient("OrganizationRestClient");
		//  var organization = restClient.GetOrganization(_component.SellerPartyId);
		//  return organization.Essentials.BankAccounts.Find(x => x.Code == _component.SellerBankAccountCode); 

		//} }

		[DisplayName("Идентфикатор контрагента продавца")]
		public long SellerPartyId { get { return _component.SellerPartyId; } }

		[DisplayName("Тип услуги")]
		public string ServiceType { get { return _component.ServiceType; } }

		[DisplayName("Уникальный номер контракта")]
		public string UniqueNumber { get { return _component.UniqueNumber; } }

		public ContractDecorator(Contract component)
		{
			_component = component;
		}
	}

	public class ContractFormulaDecorator
	{
		private readonly ContractFormula _component;

		//[DisplayName("Порядковый номер формулы в контракте")]
		//public int Number { get { return _component.Number; } }

		[DisplayName("Описание")]
		public string Description { get { return _component.Description; } }

		//[DisplayName("Тип строки в формуле")]
		//public string PriceRowTypeCode { get { return _component.PriceRowTypeCode; } }

		[DisplayName("Формула")]
		public string Formula { get { return _component.Formula; } }

		public ContractFormulaDecorator(ContractFormula component)
		{
			_component = component;
		}
	}

}
