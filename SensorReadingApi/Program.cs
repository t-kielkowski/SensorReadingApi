using MediatR;
using SensorReading.Application.Feature.GetTemperatureData;
using SensorReading.Infrastructure.Repository;
using SensorReading.Infrastructure.Repository.WeightReadings;
using SensorReading.InfrastructureChart;
using SensorReading.InfrastructureChart.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SensorReadingsContext>();
builder.Services.AddTransient<IBeehiveRepository, BeehiveRepository>();
builder.Services.AddTransient<IWeightReadingsRepository, WeightReadingsRepository>();
builder.Services.AddMediatR(typeof(GetSensorTempDataQuery));

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
