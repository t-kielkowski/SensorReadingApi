using SensorReading.Domain;

namespace SensorReading.InfrastructureChart.Repository
{
    public class SoilMoistureRepository : BaseRepository<SoilMoisture>, ISoilMoistureRepository
    {
        public SoilMoistureRepository(SensorReadingsContext dbContext) : base(dbContext)
        {
        }
    }
}
