
using Microsoft.EntityFrameworkCore;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile(path: "appsettings.json", optional: true);
builder.Configuration.AddEnvironmentVariables();



builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/* DataBase Context Dependency Injection*/
var connectionString = "Server=DESKTOP-7V70NQI\\SQLEXPRESS;Database=GymDB;trusted_connection=True;TrustServerCertificate=True;";
builder.Services.AddDbContext<API.GymDbContext>(opt => opt.UseSqlServer(connectionString));
/*======================================*/

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
