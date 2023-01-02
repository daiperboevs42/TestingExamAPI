using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingExamAPI.ProviderTest
{
    public class TestStartUp
    {
        private readonly Startup inner;

        public TestStartUp(IConfiguration configuration)
        {
            inner = new Startup(configuration);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            inner.ConfigureServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ProviderStateMiddleware>();

            inner.Configure(app, env);
        }
    }
}
