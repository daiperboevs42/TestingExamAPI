using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using TestingExamAPI.Infrastructure;
using TestingExamAPI.Core.Interfaces;
using TestingExamAPI.Infrastructure.Repositories;
using TestingExamAPI.Core.Services;
using TestingExamAPI.Core.Entities;

namespace TestingExamAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TestingExamAPIContext>(opt => opt.UseInMemoryDatabase("TestingExamAPIDb"));
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<Interest>, InterestRepository>();
            services.AddScoped<IRepository<Preference>, PreferenceRepository>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IPairingManager, PairingManager>();
            services.AddTransient<IDbInitializer, DbInitializer>();

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });
            services.AddEndpointsApiExplorer();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetService<TestingExamAPIContext>();
                var dbInitializer = services.GetService<IDbInitializer>();
                dbInitializer.Initialize(dbContext);
            }
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
