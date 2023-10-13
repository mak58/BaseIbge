using BaseIbge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

IServiceCollection serviceCollection = builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Database")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
