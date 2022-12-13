using SensorReading.Domain.Models;

namespace SensorReading.InfrastructureChart.Repository
{
    public class SHT31Repository : BaseRepository<Sht31>, ISHT31Repository
    {
        public SHT31Repository(SensorReadingsContext dbContext) : base(dbContext)
        {
        }
    }
}
