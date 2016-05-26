using System;
using System.Collections.Generic;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel;
using TicketMan.Platform.Protocol.ObjectModel.Contracts;


namespace TicketMan.Backoffice.Desktop
{
	public struct ReportFormatInfo
	{
		public string Code { get; set; }
		public string Title { get; set; }
	}

	public static class ApiUtils
	{
		public static BankAccount GetBankAccount(Contract contract, Organization organization, string BankAccountCode)
		{
			if (contract.ContractType != ContractType.AttractClient)
			{
				organization = Persistence.LoggedOrganization();
			}
			return organization.Essentials.BankAccounts.Find(x => x.Code == BankAccountCode);
		}

		public static List<ReportFormatInfo> GetReportFormats()
		{
			List<ReportFormatInfo> list = new List<ReportFormatInfo>();
			list.Add(new ReportFormatInfo { Code = "Pdf", Title = "Adobe Reader" });
			list.Add(new ReportFormatInfo { Code = "Rtf", Title = "Word" });
			list.Add(new ReportFormatInfo { Code = "Xls", Title = "Excel" });
			return list;
		}


	}
}
