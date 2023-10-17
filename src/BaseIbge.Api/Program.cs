
using BaseIbge.Application;
using BaseIbge.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServicesInfra(builder.Configuration);
builder.Services.AddServicesApp(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapIbgeCityEndpoint();

app.Run();
