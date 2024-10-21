using CarManagement.Services;
//using CarModelManagements.Interface;
using CarModelManagements.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Net;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<ICommissionService, CommissionService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddSingleton<INotificationService, NotificationService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "A simple example ASP.NET Core Web API with Swagger",
        Contact = new OpenApiContact
        {
            Name = "Your Name",
            Email = "your.email@example.com",
        }
    });
});


// Configure centralized error handling
//builder.Services.AddMiddleware<ErrorHandlingMiddleware>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error");
}



if (app.Environment.IsDevelopment())
{
    // Enable Swagger in Development environment
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // Optionally customize Swagger UI endpoint
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        c.RoutePrefix = string.Empty;  // To serve Swagger UI at the app's root (localhost:<port>/)
    });
}

//app.UseHttpsRedirection(new HttpsRedirectionOptions()
//{
//    HttpsPort = 7138  // Set the correct HTTPS port here
//});

////app.UseHttpsRedirection(new HttpsRedirectionOptions()
//{
//    HttpsPort = 7138
//});
app.UseAuthorization();
app.MapControllers();


app.Run();


