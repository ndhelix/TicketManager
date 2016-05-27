using System.Collections.Generic;
using System.Diagnostics;
using TicketMan.Platform.Api.Shared;
using TicketMan.Platform.Api.Shared.Protocol.ObjectModel.Profile;
using TicketMan.Platform.Api.Shared.Protocol.Requests;
using NUnit.Framework;

namespace TicketMan.Platform.Api.Sdk
{
    public class UserOperation
    {
        private UserRestClient CreateRestClient()
        {
            var restClient = new UserRestClient(Config.Url, Config.SiteSlug, Config.ApiKey);
            restClient.ImpersonationToken = new ImpersonationToken(Config.UserLogin, Config.UserPassword);

            return restClient;
        }


        /// <summary>
        /// Пример получения пользователя
        /// </summary>
        [Test]
        public void GetUser()
        {
            //Все данные пользователя задаются при создании RestClient
            var restClient = CreateRestClient();

            User user = restClient.GetUser("TicketMan" /*siteSlug*/, "nagaev@crog.ru" /*User login*/);

            Assert.AreEqual(Config.UserLogin, user.EmailAddress);

            Trace.WriteLine(string.Format("Пользователь: {0} {1}", user.FirstName, user.LastName));
            Trace.WriteLine("Email: " + user.EmailAddress);
            Trace.WriteLine("Организация: " + (user.OrganizationCode ?? "нет"));
        }

        /// <summary>
        /// Пример получения списка пользователей
        /// </summary>
        [Test]
        public void GetUsers()
        {
            //Все данные пользователя задаются при создании RestClient
            var restClient = CreateRestClient();

            IList<User> users = restClient.GetUsers("TicketMan" /*siteSlug*/);

            foreach (var user in users)
            {
                Trace.WriteLine(string.Format("Пользователь: {0} {1}", user.FirstName, user.LastName));
                Trace.WriteLine("Email: " + user.EmailAddress);
                Trace.WriteLine("Организация: " + (user.OrganizationCode ?? "нет"));
            }
        }



        /// <summary>
        /// Пример создания нового пользователя в системе
        /// </summary>
        [Test]
        public void CreateUser()
        {
            //Все данные пользователя задаются при создании RestClient
            var restClient = CreateRestClient();

            var createUserRequest = new CreateUserRequest();

            createUserRequest.User = new User();
            createUserRequest.User.SiteSlug = "TicketMan";
            createUserRequest.User.EmailAddress = "test@test.ru"; //Он же логин
            //createUserRequest.User.ExternalId = //Не обязательно
            createUserRequest.User.FirstName = "Петр";
            createUserRequest.User.LastName = "Иванов";
            //createUserRequest.User.OrganizationCode = //Пустой, если пользователь не член организации
            createUserRequest.User.Type = createUserRequest.User.OrganizationCode == null
                                              ? UserType.Customer
                                              : UserType.OrganizationMember;


            createUserRequest.Password = "123456"; // Или пустой, тогда сгенерируется на сервере.

            User user = restClient.CreateUser(createUserRequest);

            Assert.AreEqual("test@test.ru", user.EmailAddress);

            Trace.WriteLine(string.Format("Пользователь: {0} {1}", user.FirstName, user.LastName));
            Trace.WriteLine("Email: " + user.EmailAddress);
            Trace.WriteLine("Организация: " + (user.OrganizationCode ?? "нет"));
        }


        /// <summary>
        /// Пример редактирования нового пользователя в системе
        /// </summary>
        [Test]
        public void EditUser()
        {
            //Все данные пользователя задаются при создании RestClient
            var restClient = CreateRestClient();

            User user = restClient.GetUser("TicketMan" /*siteSlug*/, "test@test.ru" /*User login*/);

            user.FirstName = "Иван";
            user.LastName = "Иванофф";
            user.PhoneNumbers = new List<string> { "+7 123 456789" };
            user.OrganizationCode = "TicketMan";

            user = restClient.UpdateUser(user);

            Assert.AreEqual("ivanov@crog.ru", user.EmailAddress);

            Trace.WriteLine(string.Format("Пользователь: {0} {1}", user.FirstName, user.LastName));
            Trace.WriteLine("Email: " + user.EmailAddress);
            Trace.WriteLine("Организация: " + (user.OrganizationCode ?? "нет"));
        }
    }
}
