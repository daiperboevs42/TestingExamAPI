using PactNet;
using PactNet.Matchers;
using System.Collections.Generic;
using System.IO;
using Xunit.Abstractions;
using System.Net;
using System.Net.Http;
using TestingExamAPI.Consumer;
using TestingExamAPI.Core.Entities;
using TestingExamAPI.Core.Interfaces;
using Xunit;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TestingExamAPI.Tests
{
    public class UserTests
    {
        private IUserManager _userManager;
        private IPactBuilderV3 pactBuilder;
        private List<object> users;
        private readonly RequestMaker _requestMaker;
        private readonly int port = 9000;


        public UserTests(IUserManager usermanager, RequestMaker requestMaker)
        {
            this._userManager = usermanager;
            //this._pact = pact;
            this._requestMaker = requestMaker;

            // Use default pact directory ....\pacts and default log
            // directory ....\logs
            var pact = Pact.V3("RequestMaker", "UserManager", new PactConfig());

            // Initialize Rust backend
            this.pactBuilder = pact.WithHttpInteractions();

            //var Config = new PactConfig
            //{
            //    PactDir = Path.Join("..", "..", "..", "..", "..", "pacts"),
            //    LogDir = "pact_logs",
            //    Outputters = new[] { new XUnitOutput(output) },
            //    DefaultJsonSettings = new JsonSerializerSettings
            //    {
            //        ContractResolver = new CamelCasePropertyNamesContractResolver()
            //    }
            //};

            //pact = Pact.("RequestMaker", "UserManager", Config).UsingNativeBackend(port);
            //_requestMaker = new RequestMaker();
        }


        [Fact]
        public void EnsureCreation_ShouldReturnCreatedUser()
        {
                

        }

        [Fact]
        public async void EnsureGetAll_ShouldReturnAllUsers()
        {
            //Mock Users
            users = new List<object>()
            {
                new { Id = 1, Name = "Martin Park Brodersen", Email = "SomeOtherEmail@Yahoo.dk", IsAvailable = true},
                new { Id = 2, Name = "Martin Wøbbe Brodersen", Email = "SomeOtherMartin@Yahoo.dk", IsAvailable = false}
            };

            // Arrange
            pactBuilder.UponReceiving("A request for all users")
                .Given("users exists")
                .WithRequest(HttpMethod.Get, "/api/users")
                .WillRespond()
                .WithStatus(HttpStatusCode.OK)
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithJsonBody(new TypeMatcher(users));

            await pactBuilder.VerifyAsync(async ctx => {
                var response = await RequestMaker.GetAllUsers();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            });


        }

    }
}