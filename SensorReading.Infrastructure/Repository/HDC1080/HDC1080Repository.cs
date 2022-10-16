using SensorReading.Domain;

namespace SensorReading.InfrastructureChart.Repository
{
    public class HDC1080Repository : BaseRepository<Hdc1080>, IHDC1080Repository
    {
        public HDC1080Repository(SensorReadingsContext dbContext) : base(dbContext)
        {
        }
    }
}
