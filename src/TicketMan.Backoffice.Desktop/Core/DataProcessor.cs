using System;
using System.Collections.Generic;
using System.Linq;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Protocol.ObjectModel;
using TicketMan.Platform.Protocol.ObjectModel.Orders;
using TicketMan.Platform.Api.Shared.Protocol.Requests;
using TicketMan.Platform.Protocol.ObjectModel.Contracts;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel;
using TicketMan.Backoffice.Desktop.Decorators;
using System.IO;
using System.Diagnostics;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Payments;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Profile;


namespace TicketMan.Backoffice.Desktop
{
	public static class DataProcessor
	{

		//public static List<OrderDecorator> GetOrders(OrdersInfoRequest ordersInfoRequest)
		//public static IList<PaymentReportDecorator> GetPaymentReports(PaymentReportsRequest paymentReportsRequest)


		public static List<OrderInfoDecorator> GetOrders(OrdersInfoRequest ordersInfoRequest)
		{
			var restClient = (OrdersRestClient)GetRestClient("OrdersRestClient");

			var ordersInfo = restClient.GetOrdersInfo(ordersInfoRequest);
			var ordersInfoPayload = ordersInfo.Payload as OrdersInfoPayloadElement;
			var orders = ordersInfoPayload.OrdersInfo;

			return orders.ConvertAll(delegate(OrderInfo x)
			{
				var orderDecorator = new OrderInfoDecorator(x);
				return orderDecorator;
			});
		}



		public static List<PaymentReportInfoDecorator> GetPaymentReports(PaymentReportsRequest paymentReportsRequest)
		{

			if (paymentReportsRequest == null)
				paymentReportsRequest = new PaymentReportsRequest();
			var restClient = (PaymentReportsRestClient)GetRestClient("PaymentReportsRestClient");

			var paymentReports = restClient.GetPaymentReportsInfo(paymentReportsRequest);
			if (paymentReports == null)
				return null;

			//return paymentReports.ConvertAll<PaymentReportDecorator>(delegate(TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Payments.PaymentReportInfo x) { return PaymentReportDecorator(x); };

			var paymentReportDecorators = new List<PaymentReportInfoDecorator>();
			foreach (TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Payments.PaymentReportInfo paymentReportinfo in paymentReports)
			{
				var paymentReportDecorator = new PaymentReportInfoDecorator(paymentReportinfo);
				paymentReportDecorators.Add(paymentReportDecorator);
			}
			return paymentReportDecorators;
		}


		public static RestServiceClientBase GetRestClient(string type)
		{
			RestServiceClientBase restClient = null;
			switch (type)
			{
				case "OrganizationRestClient":
					restClient = new OrganizationRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
					break;
				case "PaymentReportsRestClient":
					restClient = new PaymentReportsRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
					break;
				case "OrdersRestClient":
					restClient = new OrdersRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
					break;
				case "ReportsRestClient":
					restClient = new ReportsRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
					break;
				case "ContractsRestClient":
					restClient = new ContractsRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
					break;
				case "PaymentsRestClient":
					restClient = new PaymentsRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
					break;
				case "UserRestClient":
					restClient = new UserRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
					break;
				case "ReferencesRestClient":
					restClient = new ReferencesRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
					break;
				case "SiteRestClient":
					restClient = new SiteRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
					break;
                case "OrdersDocumentsRestClient":
                    restClient = new OrdersDocumentsRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
					break;
				case "FlightsRestClient":
					restClient = new FlightsRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
					break;
				case "SystemRestClient":
					restClient = new SystemRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
					break;
				default:
					throw new Exception("RestClient type was set incorrectly.");
			}
			restClient.ImpersonationToken = new ImpersonationToken(Config.UserLogin, Config.UserPassword);
			return restClient;
		}


		public static List<OrganizationInfoDecorator> GetBuyers()
		{
			var restClient = (OrganizationRestClient)GetRestClient("OrganizationRestClient");
			var organizations = restClient.GetBuyers(ContractType.Sales);

			return (Utils.IList2LIst(organizations)).ConvertAll<OrganizationInfoDecorator>(delegate(OrganizationInfo x)
			{
				return new OrganizationInfoDecorator(x);
			});
		}

		public static List<UserDecorator> GetUsers()
		{
			var restClient = (UserRestClient)GetRestClient("UserRestClient");
			var users = restClient.GetUsers(Config.SiteSlug);
			return (Utils.IList2LIst(users)).ConvertAll<UserDecorator>(x => new UserDecorator(x));
		}

		public static List<PaymentDecorator> GetPayments()
		{
			var restClient = (PaymentsRestClient)GetRestClient("PaymentsRestClient");
            return null;
			//var payments = restClient.GetPayments();
			//if (payments == null) return null;
			//return (Utils.IList2LIst(payments)).ConvertAll<PaymentDecorator>(x => new PaymentDecorator(x));
		}

        public static List<AgencyUserDecorator> GetAgenciesUsers()
		{
            var restClient = (UserRestClient)GetRestClient("UserRestClient");
            return null;
            //var users = restClient.GetBuyersUsers();
            //if (users == null) return null;
            //return (Utils.IList2LIst(users)).ConvertAll<AgencyUserDecorator>(x => new AgencyUserDecorator(x));
		}

        public static List<SiteDecorator> GetSites()
        {
            var restClient = (SiteRestClient)GetRestClient("SiteRestClient");
            return null;
            //var sites = restClient.GetBuyerSites();
           // if (sites == null) return null;
            //return (Utils.IList2LIst(sites)).ConvertAll<SiteDecorator>(x => new SiteDecorator(x));
        }

		public static List<ContractDecorator> GetContracts(string organizationcode)
		{
			var restClient = (ContractsRestClient)GetRestClient("ContractsRestClient");
			var contracts = restClient.GetContracts(organizationcode);

			return (Utils.IList2LIst(contracts)).ConvertAll<ContractDecorator>(x => new ContractDecorator(x));
		}


		public static IList<OrganizationInfo> GetSellers()
		//public static IList<OrganizationDecorator> GetBuyers()
		{
			var restClient = (OrganizationRestClient)GetRestClient("OrganizationRestClient");
			var organizations = restClient.GetSellers(ContractType.Sales);
			//var organizations = restClient.GetChildOrganizations("aviarost");
			return organizations;
			//List<OrganizationDecorator> organizationDecorators = new List<OrganizationDecorator>();
			//foreach (OrganizationInfo organization in organizations)
			//{
			//  OrganizationDecorator organizationDecorator = new OrganizationDecorator(organization);
			//  organizationDecorators.Add(organizationDecorator);
			//}
			//return organizationDecorators;
		}

		public static void CreateReport(string orderUniqueNumber, string reportformat, string templatecode
				, string reporttype, AgencyReportRequest agencyReportRequest)
		{
			var restClient = (ReportsRestClient)GetRestClient("ReportsRestClient");
			var format = (ReportFormat)Enum.Parse(typeof(ReportFormat), reportformat, true);
			Report report = null;
			if (reporttype == "ininvoice")
				report = restClient.CreateInInvoice(orderUniqueNumber, templatecode, format);
			if (reporttype == "outinvoice")
				report = restClient.CreateOutInvoice(orderUniqueNumber, templatecode, format);
			if (reporttype == "agentreport")
				report = restClient.CreateAgentReport(agencyReportRequest, templatecode, format);

			string uniquenumber = orderUniqueNumber ?? agencyReportRequest.OrganizationCode;
			string filename = reporttype + "_" + uniquenumber + "_" + DateTime.Now.ToString("MMdd_HHmmss") + "." + reportformat; 
			var filePath = Path.Combine(Path.GetTempPath(), filename);
			File.WriteAllBytes(filePath, report.Content);
			Process.Start(new ProcessStartInfo { FileName = filePath, UseShellExecute = true });
		}

		public static ReportTemplate GetReportTemplate(string reportType, string code)
		{
			var restClient = (ReportsRestClient)GetRestClient("ReportsRestClient");
			//var reportTemplates = restClient.GetReportTemplatesInfo();
			//string firstTypeCode = reportTemplates.First().TypeCodes[0];
			return restClient.GetReportTemplate(reportType, code);
		}

		public static List<TicketMan.Platform.Api.Shared.Protocol.ObjectModel.ServiceType> GetServiceTypes()
		{
			ReferencesRestClient restClient = (ReferencesRestClient)GetRestClient("ReferencesRestClient");
			return restClient.GetServiceTypes();
		}


	}
}
