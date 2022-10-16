using SensorReading.Domain;

namespace SensorReading.InfrastructureChart.Repository
{
    public class BMP280Repository : BaseRepository<Bmp280>, IBMP280Repository
    {
        public BMP280Repository(SensorReadingsContext dbContext) : base(dbContext)
        {
        }
    }
}
