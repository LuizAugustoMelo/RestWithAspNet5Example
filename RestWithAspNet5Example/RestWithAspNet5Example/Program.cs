using Microsoft.EntityFrameworkCore;
using RestWithAspNet5Example.Model.Context;
using RestWithAspNet5Example.Business;
using RestWithAspNet5Example.Business.Implemantations;
using RestWithAspNet5Example.Repository;
using RestWithAspNet5Example.Repository.Implemantations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Set/Get connection database string
var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));
//Versioning API
builder.Services.AddApiVersioning();

builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
