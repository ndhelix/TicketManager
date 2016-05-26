using System.Diagnostics;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Exceptions;
using NUnit.Framework;

namespace TicketMan.Platform.Api.Sdk
{
    public class AuthorizationOperation
    {
        private UserRestClient CreateRestClient()
        {
            var restClient = new UserRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
            restClient.ImpersonationToken = new ImpersonationToken(Config.UserLogin, Config.UserPassword);

            return restClient;
        }


        /// <summary>
        /// Пример аутентификации пользователя в АПИ.
        /// 
        /// Сама по себе аутентификация производится при запросе к АПИ.
        /// Сервер не хранит состояние авторизации между запросами. 
        /// Данный пример показывает организацию доступа клиента к ресурсам АПИ на стороне клиента.
        /// </summary>
        [Test]
        public void AuthenticationUser()
        {
            //Все данные пользователя задаются при создании RestClient
            var restClient = CreateRestClient();

            try
            {
                var user = restClient.GetCurrentUser();

                Assert.AreEqual(Config.UserLogin, user.EmailAddress);

                Trace.WriteLine(string.Format("Пользователь: {0} {1}", user.FirstName, user.LastName));
                Trace.WriteLine("Email: " + user.EmailAddress);
                Trace.WriteLine("Организация: " + user.OrganizationCode ?? "нет");
            } catch (AuthorizationApiException e)
            {
                Trace.WriteLine("Пользоввтель не авторизован: " + e.Message);
            }
        }
    }
}
