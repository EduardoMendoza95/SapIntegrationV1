// using System.Reflection;
// using MediatR;
// using Microsoft.OpenApi.Models;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Wee.SapIntegration.Infrastructure.Services;
// using Wee.SapIntegration.Infrastructure.Data; 
// using Wee.SapIntegration.Application.Features.Interfaces;

// using System.Globalization;

// // Forzar cultura invariante para evitar error de globalización
// CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
// CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container
// builder.Services
//     .AddControllers()
//     .AddNewtonsoftJson();

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// // MediatR
// builder.Services.AddMediatR(typeof(Wee.SapIntegration.Application.Features.Autenticacion.Commands.GenerarTokenCommand).Assembly);

// // HttpClient
// builder.Services.AddHttpClient();

// // Registro de servicios personalizados
// builder.Services.AddScoped<ITokenService, TokenService>();
// builder.Services.AddScoped<IAltaClienteService, AltaClienteService>();
// builder.Services.AddScoped<IClientePayloadBuilder, ChopoAltaClientePayloadBuilder>(); // <--- ESTE FALTABA

// // // LogService (si lo sigues usando)
// // builder.Services.AddScoped<LogService>();

// // AppDbContext - usar SQL Server (cambia si usas otro motor)
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Asegúrate de tener esta cadena en appsettings.json

// var app = builder.Build();

// // Middleware
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();
// app.UseAuthorization();
// app.MapControllers();
// app.Run();

using System.Globalization;
Console.WriteLine(CultureInfo.GetCultureInfo("en-US").DisplayName);