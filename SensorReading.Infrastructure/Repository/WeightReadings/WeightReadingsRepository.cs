using Microsoft.EntityFrameworkCore;
using SensorReading.Domain.Models;
using SensorReading.InfrastructureChart;
using SensorReading.InfrastructureChart.Repository;

namespace SensorReading.Infrastructure.Repository.WeightReadings
{
    public class WeightReadingsRepository : BaseRepository<WeightReading>, IWeightReadingsRepository
    {
        public WeightReadingsRepository(SensorReadingsContext dbContext) : base(dbContext)
        {}

        public async Task<IEnumerable<WeightReading>> GetTempByIdAsync(IWeightReadingsSearchParams searchParams)
        {
            var query = DbContext.WeightReadings
                .Where(x => x.WeightId == searchParams.WeightId);

            if (searchParams.DateFrom.HasValue)            
                query = query.Where(x => x.ReadingTime >= searchParams.DateFrom);

            if (searchParams.DateTo.HasValue)
                query = query.Where(x => x.ReadingTime <= searchParams.DateTo);

            var result = await query
                 .AsNoTracking()
                .AsSingleQuery()
                .Select(x=> new WeightReading
                {
                    Temperature= x.Temperature,
                    ReadingTime= x.ReadingTime
                })
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<WeightReading>> GetMoisByIdAsync(IWeightReadingsSearchParams searchParams)
        {
            var query = DbContext.WeightReadings
                .Where(x => x.WeightId == searchParams.WeightId);

            if (searchParams.DateFrom.HasValue)
                query = query.Where(x => x.ReadingTime >= searchParams.DateFrom);

            if (searchParams.DateTo.HasValue)
                query = query.Where(x => x.ReadingTime <= searchParams.DateTo);

            var result = await query
                 .AsNoTracking()
                .AsSingleQuery()
                .Select(x => new WeightReading
                {
                    Moisture = x.Moisture,
                    ReadingTime = x.ReadingTime
                })
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<WeightReading>> GetWeightByIdAsync(IWeightReadingsSearchParams searchParams)
        {
            var query = DbContext.WeightReadings
                .Where(x => x.WeightId == searchParams.WeightId);

            if (searchParams.DateFrom.HasValue)
                query = query.Where(x => x.ReadingTime >= searchParams.DateFrom);

            if (searchParams.DateTo.HasValue)
                query = query.Where(x => x.ReadingTime <= searchParams.DateTo);

            var result = await query
                 .AsNoTracking()
                .AsSingleQuery()
                .Select(x => new WeightReading
                {
                    Weight = x.Weight,
                    ReadingTime = x.ReadingTime
                })
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<WeightReading>> GetBaterryLevelByIdAsync(IWeightReadingsSearchParams searchParams)
        {
            var query = DbContext.WeightReadings
                .Where(x => x.WeightId == searchParams.WeightId);

            if (searchParams.DateFrom.HasValue)
                query = query.Where(x => x.ReadingTime >= searchParams.DateFrom);

            if (searchParams.DateTo.HasValue)
                query = query.Where(x => x.ReadingTime <= searchParams.DateTo);

            var result = await query
                 .AsNoTracking()
                .AsSingleQuery()
                .Select(x => new WeightReading
                {
                    BatteryLevel = x.BatteryLevel,
                    ReadingTime = x.ReadingTime
                })
                .ToListAsync();

            return result;
        }
    }
}
