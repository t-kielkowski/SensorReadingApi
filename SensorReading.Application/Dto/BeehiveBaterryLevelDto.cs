namespace SensorReading.Application.Dto
{
    public class BeehiveBatteryLevelDto
    {
        public IEnumerable<string> BatteryLevel { get; set; }
        public IEnumerable<string> ReadingTime { get; set; }
    }
}
