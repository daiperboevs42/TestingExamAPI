using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using PactNet;
using TestingExamAPI.Consumer;
using TestingExamAPI.Consumer.Entities;
using Xunit;

namespace TestingExamAPI.Tests
{
    public class UserTests
    {
            private readonly IPactBuilderV3 pactBuilder;

            public UserTests()
            {
                // Use default pact directory ..\..\pacts and default log
                // directory ..\..\logs
                var pact = Pact.V3("User API Consumer", "User API", new PactConfig());

                // Initialize Rust backend
                this.pactBuilder = pact.WithHttpInteractions();
            }

            [Fact]
            public async Task GetUserTest()
            {

                // Arrange
                this.pactBuilder
                    .UponReceiving("A GET request to retrieve a User")
                        .Given("There is a user with the ID 3")
                        .WithRequest(HttpMethod.Get, "/user")
                    .WillRespond()
                        .WithStatus(HttpStatusCode.OK)
                        .WithHeader("Content-Type", "application/json; charset=utf-8")
                        .WithJsonBody(new
                        { Id = 3,
                            Name = "Tienesh Sivasubremaniyam",
                            Email = "SomeSeperateEmail@Yahoo.dk",
                            IsAvailable = true,
                        });

                await this.pactBuilder.VerifyAsync(async ctx =>
                {
                    // Act
                    var client = new RequestMaker(ctx.MockServerUri);
                    User User = RequestMaker.GetSpecificUser(3).GetAwaiter().GetResult();
                    
                    // Assert
                    Assert.Equal("3", User.Id.ToString());
                });
            }
        

    }
}