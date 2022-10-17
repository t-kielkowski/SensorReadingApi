using MediatR;
using SensorReading.Application.Feature.Beehive;
using SensorReading.InfrastructureChart;
using SensorReading.InfrastructureChart.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SensorReadingsContext>();
builder.Services.AddTransient<IBH1750Repository, BH1750Repository>();
builder.Services.AddTransient<IBMP280Repository, BMP280Repository>();
builder.Services.AddTransient<IHDC1080Repository, HDC1080Repository>();
builder.Services.AddTransient<ISHT31Repository, SHT31Repository>();
builder.Services.AddTransient<ISHT31TestRepository, SHT31TestRepository>();
builder.Services.AddTransient<ISoilMoistureRepository, SoilMoistureRepository>();
builder.Services.AddMediatR(typeof(GetSensorDataQuery));

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
