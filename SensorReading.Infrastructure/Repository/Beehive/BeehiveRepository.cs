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

        public async Task<List<string>> BeehiveList()
        {
            var result = await DbContext.WeightReadings.FromSqlRaw("SELECT WeightId FROM `WeightReadings` GROUP BY WeightId").AsNoTracking().ToListAsync();

            var beehiveList = new List<string>();

            if (result is not null && result.Count > 0)
                foreach (var item in result)
                    if (!string.IsNullOrEmpty(item.WeightId))
                        beehiveList.Add(item.WeightId);

            return beehiveList;
        }
    }
}
