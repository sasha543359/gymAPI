using GymDbContext_.Data.Services.CustomerService;
using GymDbContext_.Data.Services.WorkerService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile(path: "appsettings.json", optional: true);
builder.Configuration.AddEnvironmentVariables();



builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/* DataBase Context Dependency Injection*/

builder.Services.AddDbContext<API.GymDbContext>();
/*======================================*/
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IWorkerService, WorkerService>();

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
