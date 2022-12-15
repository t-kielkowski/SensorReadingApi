namespace SensorReading.Infrastructure.Repository.WeightReadings
{
    public interface IWeightReadingsSearchParams
    {
        public string WeightId { get; set; }

        public DateTime? DateFrom { get; set; }
 
        public DateTime? DateTo { get; set; }  
    }
}
