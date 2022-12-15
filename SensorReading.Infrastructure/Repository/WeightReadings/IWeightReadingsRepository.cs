using SensorReading.Domain.Models;
using SensorReading.InfrastructureChart.Repository;

namespace SensorReading.Infrastructure.Repository.WeightReadings
{
    public interface IWeightReadingsRepository : IBaseRepository<WeightReading>
    {
        public Task<IEnumerable<WeightReading>> GetTempByIdAsync(IWeightReadingsSearchParams searchParams);
        public Task<IEnumerable<WeightReading>> GetMoisByIdAsync(IWeightReadingsSearchParams searchParams);
        public Task<IEnumerable<WeightReading>> GetWeightByIdAsync(IWeightReadingsSearchParams searchParams);
        public Task<IEnumerable<WeightReading>> GetBaterryLevelByIdAsync(IWeightReadingsSearchParams searchParams);
    }
}
