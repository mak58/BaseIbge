var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServicesInfra(builder.Configuration);
builder.Services.AddServicesApp(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

var versionSet = app.NewApiVersionSet()
    .HasApiVersion(new ApiVersion(1, 0))    
    .ReportApiVersions()
    .Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapIbgeCityEndpoint(versionSet);
app.MapUserEndpoint(versionSet);
app.MapTokenEndpoint(versionSet);

// app.UseHttpsRedirection();

app.Run();
