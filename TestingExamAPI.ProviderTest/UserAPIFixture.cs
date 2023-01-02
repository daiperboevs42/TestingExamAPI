using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingExamAPI.ProviderTest
{
    public class UserAPIFixture : IDisposable
    {
        private readonly IHost server;
        public Uri ServerUri { get; }

        public UserAPIFixture()
        {
            ServerUri = new Uri("http://localhost:49735");
            server = Host.CreateDefaultBuilder()
                            .ConfigureWebHostDefaults(webBuilder =>
                            {
                                webBuilder.UseUrls(ServerUri.ToString());
                                webBuilder.UseStartup<TestStartUp>();
                            })
                            .Build();
            server.Start();
        }
        public void Dispose()
        {
            server.Dispose();

            // Clean out leftover data
            //foreach (var dataFile in Directory.GetFiles(Path.Combine("..", "..", "..","..", "data")))
            //{
            //    File.Delete(dataFile);
            //}
        }
    }
}
