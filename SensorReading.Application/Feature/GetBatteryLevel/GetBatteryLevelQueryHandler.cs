using MediatR;
using SensorReading.Application.Dto;
using SensorReading.Infrastructure.Repository.WeightReadings;

namespace SensorReading.Application.Feature.GetBatteryLevel
{
    internal class GetBatteryLevelQueryHandler : IRequestHandler<GetBatteryLevelQuery, IEnumerable<BeehiveBatteryLevelDto>>
    {
        private readonly IWeightReadingsRepository _weightReadingsRepository;

        public GetBatteryLevelQueryHandler(IWeightReadingsRepository weightReadingsRepository)
        {
            _weightReadingsRepository = weightReadingsRepository;
        }

        public async Task<IEnumerable<BeehiveBatteryLevelDto>> Handle(GetBatteryLevelQuery request, CancellationToken cancellationToken)
        {
            var result = await _weightReadingsRepository.GetTempByIdAsync(request.SearchParams).ConfigureAwait(false);

            return result.Select(x => new BeehiveBatteryLevelDto()
            {
                BatteryLevel = string.IsNullOrEmpty(x.BatteryLevel) ? "0" : x.BatteryLevel,
                ReadingTime = x.ReadingTime.ToString()
            });
        }
    }
}
