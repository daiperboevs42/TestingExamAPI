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
                var pact = Pact.V3("Something API Consumer", "Something API", new PactConfig());

                // Initialize Rust backend
                this.pactBuilder = pact.WithHttpInteractions();
            }

            [Fact]
            public async Task GetUserTest()
            {

                // Arrange
                this.pactBuilder
                    .UponReceiving("A GET request to retrieve the something")
                        .Given("There is a user with the ID 1")
                        .WithRequest(HttpMethod.Get, "/somethings/tester")
                        .WithHeader("Accept", "application/json")
                    .WillRespond()
                        .WithStatus(HttpStatusCode.OK)
                        .WithHeader("Content-Type", "application/json; charset=utf-8")
                        .WithJsonBody(new
                        { Id = 1, 
                            Name = "Martin Park Brodersen", 
                            Email = "SomeOtherEmail@Yahoo.dk", 
                            IsAvailable = true 
                        });

                await this.pactBuilder.VerifyAsync(async ctx =>
                {
                    // Act
                    var client = new RequestMaker(ctx.MockServerUri);
                    var User = await client.GetSpecificUser();

                    // Assert
                    Assert.Equal("user", User.Id);
                });
            }
        

    }
}