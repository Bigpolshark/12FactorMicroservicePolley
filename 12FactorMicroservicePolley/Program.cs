using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TwelveFactorMicroservicePolley.Data;
using TwelveFactorMicroservicePolley.BusinessLogic;

//DB Connection
string dbName = "TwelveFactorMicroservicePolleyNetworkDB";
string dbUser = "sa";
string dbPW = "MsSqlServer1#";
//string dbPort = "1433";
//string connectionString = "Data Source = " + dbName + "," + dbPort + "; User ID = " + dbUser + "; Password = " + dbPW + ";";
string connectionString = "Data Source = " + dbName + "; User ID = " + dbUser + "; Password = " + dbPW + ";";

//DB Setup
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbContext12Factor>(options =>
    options.UseSqlServer(connectionString));

//Dependency Injection
builder.Services.AddTransient<IRepository, Repository12Factor>();
builder.Services.AddTransient<IBusinessLogic12Factor, BusinessLogic12Factor>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
