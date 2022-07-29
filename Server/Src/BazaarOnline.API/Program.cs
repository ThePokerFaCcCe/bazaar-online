using BazaarOnline.Infra.Data.Contexts;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// DotNetEnv
DotNetEnv.Env.Load();

builder.Services.AddControllers();

// DB
builder.Services.AddDbContext<BazaarDbContext>(options =>
    options.UseSqlServer(DotNetEnv.Env.GetString("CONNECTION_STRING")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("V1", new OpenApiInfo
    {
        Version = "V1",
        Title = "Bazaar API",
        Description = "Main API Documentation of Bazaar API",
        License = new OpenApiLicense { Name = "MIT" },
        Contact = new OpenApiContact
        {
            Email = "matin.khaleghi.nezhad@gmail.com",
            Name = "Matin Khaleghi"
        }
    });
});
// Fluent Validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationRulesToSwagger();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/V1/swagger.json", "V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
