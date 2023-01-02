using TestingExamAPI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Provider.Tests
{
    public class TestStartup
    {
        private StartUp inner;

        public TestStartup()
        {
            inner = new StartUp();
        }

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    inner.ConfigureServices(services);
        //}

        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    app.UseMiddleware<ProviderStateMiddleware>();

        //    inner.Configure(app, env);
        //}
    }
}