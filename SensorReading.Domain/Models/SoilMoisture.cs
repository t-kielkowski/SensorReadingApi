namespace SensorReading.Domain
{
    public partial class SoilMoisture
    {
        public uint Id { get; set; }
        public string? Moisture { get; set; }
        public DateTime ReadingTime { get; set; }
    }
}
