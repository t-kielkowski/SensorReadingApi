using SensorReading.Application.Dto.Beehive;
using SensorReading.Domain;

namespace SensorReading.Application.Mapping
{
    internal static class Sht31Mapping
    {
        public static Sht31TempDto ToTemperatureDto(this Sht31 sensor)
        {
            return new Sht31TempDto
            {
                Temperature = string.IsNullOrEmpty(sensor.Temperature) ? "0" : sensor.Temperature.ToString(),
                ReadingTime = sensor.ReadingTime.ToString()
            };
        }

        public static Sht31MoisDto ToMoistureDto(this Sht31 sensor)
        {

            return new Sht31MoisDto
            {
                Moisture = string.IsNullOrEmpty(sensor.Moisture) ? "0" : sensor.Moisture.ToString(),
                ReadingTime = sensor.ReadingTime.ToString()
            };
        }
    }
}
