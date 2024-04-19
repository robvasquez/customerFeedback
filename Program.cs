using CustomerFeedbackSystem;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CustomerFeedbackSystem.Data;
using CustomerFeedbackSystem.Repositories;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Optionally keep using the Startup class if it helps organize configuration
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline using the Startup class.
startup.Configure(app, app.Environment);

app.Run();