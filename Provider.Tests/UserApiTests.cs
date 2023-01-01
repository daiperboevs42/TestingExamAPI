using PactNet;
using PactNet.Infrastructure.Outputters;
using PactNet.Verifier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Provider.Tests
{
    public class UserApiTests : IClassFixture<UserApiFixture>
    {
        private readonly UserApiFixture fixture;
        private readonly ITestOutputHelper output;

        public UserApiTests(UserApiFixture fixture, ITestOutputHelper output)
        {
            this.fixture = fixture;
            this.output = output;
        }

        [Fact]
        public void EnsureSomethingApiHonoursPactWithConsumer()
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
                    new XUnitOutput(output),
                },
            };

            string pactPath = Path.Combine("..",
                                           "..",
                                           "..",
                                           "..",
                                           "pacts",
                                           "User.json");

            // Act / Assert
            IPactVerifier pactVerifier = new PactVerifier(config);
            pactVerifier
                .ServiceProvider("User API", fixture.ServerUri)
                .WithFileSource(new FileInfo(pactPath))
                .WithProviderStateUrl(new Uri(fixture.ServerUri, "/provider-states"))
                .Verify();
        }

    }
}
