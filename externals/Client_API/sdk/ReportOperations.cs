using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel;
using TicketMan.Platform.Api.Shared.Protocol.Requests;
using NUnit.Framework;

namespace TicketMan.Platform.Api.Sdk
{
    /// <summary>
    /// Примеры работы с отчетами
    /// </summary>
    public class ReportOperations
    {
        private ReportsRestClient CreateRestClient()
        {
            var restClient = new ReportsRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
            restClient.ImpersonationToken = new ImpersonationToken(Config.UserLogin, Config.UserPassword);

            return restClient;
        }


        /// <summary>
        /// Пример генерации отчета
        /// </summary>
        [Test]
        public void CreateOutInvoice()
        {
            ReportsRestClient restClient = CreateRestClient();

            Report report = restClient.CreateOutInvoice("73FC6" /*Номер заявки*/, null /*Стандартный шаблон отчета*/, ReportFormat.Pdf /*формат файла*/);

            //Сохраняем присланные байты в файл
            string filePath = Path.Combine(Path.GetTempPath(), report.Name /*Это имя вполне подойдет для названия файла*/);
            File.WriteAllBytes(filePath, report.Content);

            //Запускаем файл в связанном приложении
            Process.Start(new ProcessStartInfo {FileName = filePath, UseShellExecute = true});
        }

        [Test]
        public void CreateFlightsAgency()
        {
            ReportsRestClient restClient = CreateRestClient();

            var agencyReportRequest = new AgencyReportRequest();
            agencyReportRequest.ServiceType = "flights";
            agencyReportRequest.OrganizationCode = "sputnik";
            agencyReportRequest.BeginDate = DateTime.Parse("2012.01.01");
            agencyReportRequest.EndDate = DateTime.Now;

            Report report = restClient.CreateAgentReport(agencyReportRequest, null /*Стандартный шаблон отчета*/, ReportFormat.Pdf /*формат файла*/);

            //Сохраняем присланные байты в файл
            string filePath = Path.Combine(Path.GetTempPath(), report.Name /*Это имя вполне подойдет для названия файла*/);
            File.WriteAllBytes(filePath, report.Content);

            //Запускаем файл в связанном приложении
            Process.Start(new ProcessStartInfo { FileName = filePath, UseShellExecute = true });
        }

        /// <summary>
        /// Пример генерации отчета
        /// </summary>
        [Test]
        public void CreateIssuedOrderReport()
        {
            ReportsRestClient restClient = CreateRestClient();

            var reportRequest = new IssuedOrdersReportRequest();
            reportRequest.BeginDate = DateTime.Parse("2012.05.01");
            reportRequest.EndDate = DateTime.Parse("2012.06.01");
            reportRequest.ServiceType = "flights";

            Report report = restClient.CreateIssuedOrdersReport(reportRequest, null /*Стандартный шаблон отчета*/, ReportFormat.Pdf /*формат файла*/);

            //Сохраняем присланные байты в файл
            string filePath = Path.Combine(Path.GetTempPath(), report.Name /*Это имя вполне подойдет для названия файла*/);
            File.WriteAllBytes(filePath, report.Content);

            //Запускаем файл в связанном приложении
            Process.Start(new ProcessStartInfo { FileName = filePath, UseShellExecute = true });
        }

        /// <summary>
        /// Пример генерации отчета
        /// </summary>
        [Test]
        public void CreateAccountingReport()
        {
            ReportsRestClient restClient = CreateRestClient();

            var reportRequest = new AccountingReportRequest();
            reportRequest.BeginDate = DateTime.Parse("2012.09.01");
            reportRequest.EndDate = DateTime.Parse("2012.10.01");
            reportRequest.ServiceType = "flights";

            Report report = restClient.CreateAccauntingReport(reportRequest, null /*Стандартный шаблон отчета*/, ReportFormat.Xlsx /*формат файла*/);

            //Сохраняем присланные байты в файл
            string filePath = Path.Combine(Path.GetTempPath(), report.Name /*Это имя вполне подойдет для названия файла*/);
            File.WriteAllBytes(filePath, report.Content);

            //Запускаем файл в связанном приложении
            Process.Start(new ProcessStartInfo { FileName = filePath, UseShellExecute = true });
        }

        /// <summary>
        /// Пример получения всех типов отчета.
        /// </summary>
        [Test]
        public void GetReportTypes()
        {
            ReportsRestClient restClient = CreateRestClient();

            IList<ReportType> reportTypes = restClient.GetReportTypes();

            Assert.NotNull(reportTypes);
            Assert.Greater(reportTypes.Count, 0);
        }

        /// <summary>
        /// Пример получения всех шаблонов отчета.
        /// Возвращается только базовая информация о шаблонах.
        /// Сам шаблон можно получить только по его коду. Смотри <see cref="GetReportTemplate"/> ниже.
        /// </summary>
        [Test]
        public void GetReportTemplates()
        {
            ReportsRestClient restClient = CreateRestClient();

            IList<ReportTemplateInfo> reportTemplates = restClient.GetReportTemplatesInfo();

            Assert.NotNull(reportTemplates);
            Assert.Greater(reportTemplates.Count, 0);

            //Создаем словарь шаблонов по их типам
            Dictionary<string, List<ReportTemplateInfo>> templatesByType =
                (from reportTemplate in reportTemplates
                 from typeCode in reportTemplate.TypeCodes
                 select new {reportTemplate, typeCode})
                    .GroupBy(item => item.typeCode)
                    .ToDictionary(group => group.Key, group => group.Select(item =>item.reportTemplate).ToList());
                

            //Теперь очень просто получить все шаблоны по заданному типу.
            List<ReportTemplateInfo> templatesForInInvoice = templatesByType["ininvoice"];

            Assert.Greater(templatesForInInvoice.Count, 0);
        }

        /// <summary>
        /// Пример получения всех шаблонов отчета.
        /// </summary>
        [Test]
        public void GetReportTemplate()
        {
            ReportsRestClient restClient = CreateRestClient();

            IList<ReportTemplateInfo> reportTemplates = restClient.GetReportTemplatesInfo();

            string firstTypeCode = reportTemplates.First().TypeCodes.First();

            //Если в качестве второго праметра передан null, вернется базовый шаблон general.
            ReportTemplate reportType = restClient.GetReportTemplate(firstTypeCode, null /*reportTemplateCode*/);

            Assert.NotNull(reportType);
            Assert.NotNull(reportType.TemplateContent); //В этом массиве байтов содержится шаблон XtraReport (см. http://help.devexpress.com/#XtraReports/CustomDocument2162)
        }

        /// <summary>
        /// Пример получения всех шаблонов отчета.
        /// </summary>
        [Test]
        public void CreateNewReportTemplate()
        {
            ReportsRestClient restClient = CreateRestClient();

            //Получаем общий шаблон
            var generalTemplate = restClient.GetReportTemplate("ininvoice", null /*reportTemplateCode*/);


            var reportTemplate = new ReportTemplate();

            reportTemplate.Code = Guid.NewGuid().ToString();
            reportTemplate.Name = "Тестовый шаблон, скопированный с общего";

            reportTemplate.TypeCodes = new List<string>{"ininvoice"};
            reportTemplate.TemplateContent = generalTemplate.TemplateContent.Clone() as byte[];

            //Тут редактируем reportTemplate.TemplateContent в XtraReport.

            restClient.SaveReportTemplate(reportTemplate);

            //Если не возникло исключения и мы оказались тут — значит все сохранилось.
         }

    }
}
