using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using CustomerFeedbackSystem;

var builder = WebApplication.CreateBuilder(args);

// Instead of configuring services here, use the Startup class.
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);


var app = builder.Build();

// Configure the HTTP request pipeline using the Startup class.
startup.Configure(app, app.Environment);

app.Run();
