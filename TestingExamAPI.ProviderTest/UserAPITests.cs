using PactNet;
using PactNet.Infrastructure.Outputters;
using PactNet.Verifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace TestingExamAPI.ProviderTest
{
    public class UserAPITests : IClassFixture<UserAPIFixture>
    {
        private readonly UserAPIFixture _fixture;
        private readonly ITestOutputHelper _output;

        public UserAPITests(UserAPIFixture fixture, ITestOutputHelper output)
        {
            _fixture = fixture;
            _output = output;
        }

        [Fact]
        public void EnsureUserApiHonoursPactWithConsumer()
        {
            // Arrange 
            var config = new PactVerifierConfig
            {
                Outputters = new List<IOutput>
                {
                    // NOTE: PactNet defaults to a ConsoleOutput, however
                    // xUnit 2 does not capture the console output, so this
                    // sample creates a custom xUnit outputter. You will
                    // have to do the same in xUnit projects.
                    new XUnitOutput(_output),
                },
            };

            string pactPath = Path.Combine("..",
                                           "..",
                                           "..",
                                           "..",
                                           "pacts",
                                           "User API Consumer API.json");

            // Act / Assert
            IPactVerifier pactVerifier = new PactVerifier(config);
            pactVerifier
                .ServiceProvider("User API", _fixture.ServerUri)
                .WithFileSource(new FileInfo(pactPath))
                .WithProviderStateUrl(new Uri(_fixture.ServerUri, "/provider-states"))
                .Verify();
        }
        //[Fact]
        //public void UsersExist()
        //{

        //}
    }

}
