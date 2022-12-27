using Microsoft.EntityFrameworkCore;
using TestingExamAPI.Core.Entities;
using TestingExamAPI.Core.Interfaces;
using TestingExamAPI.Core.Services;
using TestingExamAPI.Infrastructure;
using TestingExamAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TestingExamAPIContext>(opt => opt.UseInMemoryDatabase("TestingExamAPIDb"));

builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<Interest>, InterestRepository>();
builder.Services.AddScoped<IRepository<Preference>, PreferenceRepository>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IPairingManager, PairingManager>();
builder.Services.AddTransient<IDbInitializer, DbInitializer>();


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var dbContext = services.GetService<TestingExamAPIContext>();
        var dbInitializer = services.GetService<IDbInitializer>();
        dbInitializer.Initialize(dbContext);
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
