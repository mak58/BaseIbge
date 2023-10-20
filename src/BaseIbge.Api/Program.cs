var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServicesInfra(builder.Configuration);
builder.Services.AddServicesApp();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapIbgeCityEndpoint();
app.MapUserEndpoint();
app.MapTokenEndpoint();

app.Run();
