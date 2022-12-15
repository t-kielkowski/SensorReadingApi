using Microsoft.EntityFrameworkCore;
using SensorReading.InfrastructureChart;

namespace SensorReading.Infrastructure.Repository
{
    public class BeehiveRepository : IBeehiveRepository
    {
        protected readonly SensorReadingsContext DbContext;

        public BeehiveRepository(SensorReadingsContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<ICollection<string?>> BeehiveList()
        {
            var result = new List<string>();

            return await DbContext
                .WeightReadings
                .GroupBy(bee => bee.WeightId)
                .Select(id => id.Key)
                .ToListAsync();         
        }
    }
}
