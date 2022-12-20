using Microsoft.EntityFrameworkCore;
using RestWithAspNet5Example.Model.Context;
using RestWithAspNet5Example.Business;
using RestWithAspNet5Example.Business.Implemantations;
using RestWithAspNet5Example.Repository;
using Serilog;
using MySqlConnector;
using EvolveDb;
using RestWithAspNet5Example.Repository.Generic;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
// Add services to the container.

builder.Services.AddControllers();

//Set/Get connection database string
var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));
//Versioning API
builder.Services.AddApiVersioning();

builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
	try
	{
		var evolveConnection = new MySqlConnection(connection);
		var evolve = new Evolve(evolveConnection, msg => Log.Information(msg))
		{
			Locations = new List<string> { "db/migrations", "db/dataset" },
			IsEraseDisabled = true,
		};
		evolve.Migrate();
	}
	catch (Exception ex)
	{
		Log.Error("Dtabase Migration failed", ex);
		throw;
	}
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
