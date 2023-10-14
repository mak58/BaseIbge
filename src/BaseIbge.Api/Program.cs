using BaseIbge.Infrastructure.Data;
using BaseIbge.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using static BaseIbge.Infrastructure.Repositories.RepositoryBase;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
