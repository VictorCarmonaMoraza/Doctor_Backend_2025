using API_DOCTOR.Extension;
using Doctor_Data.DB_Context;
using Doctor_Data.Interfaces;
using Doctor_Data.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//Ovbtenenemos nuestro servicio de extension
builder.Services.AddServiceAplication(builder.Configuration);

//Obtrenemos extension de Identity
builder.Services.AddServiceAplicationIdentity(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//CORS
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

//Authentication
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
