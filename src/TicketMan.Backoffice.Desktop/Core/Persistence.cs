using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketMan.Backoffice.Desktop.Decorators;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel;
using TicketMan.Platform.Api.Shared;

namespace TicketMan.Backoffice.Desktop
{
	public static class Persistence
	{
		static IList<ReportTemplateInfo> _reportTemplatesInfo; //singleton
		static Organization _loggedOrganization; //singleton
		static List<OrganizationInfoDecorator> _buyers; //singleton

		public static IList<ReportTemplateInfo> GetReportTemplatesInfo(bool reload = false)
		{
			if (_reportTemplatesInfo == null || reload)
			{
				var restClient = (ReportsRestClient)DataProcessor.GetRestClient("ReportsRestClient");
				_reportTemplatesInfo = restClient.GetReportTemplatesInfo();
			}
			return _reportTemplatesInfo;
		}

		public static Organization LoggedOrganization()
		{
			if (_loggedOrganization == null)
			{
				var siteRestClient = (SiteRestClient)DataProcessor.GetRestClient("SiteRestClient");
				var org = siteRestClient.GetSite(Config.SiteSlug);

				var restClient = (OrganizationRestClient)DataProcessor.GetRestClient("OrganizationRestClient");
				_loggedOrganization = restClient.GetOrganization(org.OrganizationCode);
			}
			return _loggedOrganization;
		}

		public static List<OrganizationInfoDecorator> GetBuyers(bool reload = false)
		{
			if (_buyers == null || reload)
			{
				_buyers = DataProcessor.GetBuyers();
			}
			return _buyers;			
		}

		public static OrganizationInfoDecorator FindAgency(string keyword)
		{
			var buyers = GetBuyers();
            buyers.Add(new OrganizationInfoDecorator(LoggedOrganization()));
			var buyer = buyers.Find(x => x.Code.Contains(keyword)) ?? buyers.Find(x => x.FullName.Contains(keyword));
			return buyer;
		}
	}
}
