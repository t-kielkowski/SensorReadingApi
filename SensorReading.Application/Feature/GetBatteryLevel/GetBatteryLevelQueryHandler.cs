using MediatR;
using SensorReading.Application.Dto;
using SensorReading.Infrastructure.Repository.WeightReadings;

namespace SensorReading.Application.Feature.GetBatteryLevel
{
    internal class GetBatteryLevelQueryHandler : IRequestHandler<GetBatteryLevelQuery, BeehiveBatteryLevelDto>
    {
        private readonly IWeightReadingsRepository _weightReadingsRepository;

        public GetBatteryLevelQueryHandler(IWeightReadingsRepository weightReadingsRepository)
        {
            _weightReadingsRepository = weightReadingsRepository;
        }

        public async Task<BeehiveBatteryLevelDto> Handle(GetBatteryLevelQuery request, CancellationToken cancellationToken)
        {
            var result = await _weightReadingsRepository.GetTempByIdAsync(request.SearchParams).ConfigureAwait(false);

            return new BeehiveBatteryLevelDto()
            {
                BatteryLevel = result.Select(x => string.IsNullOrEmpty(x.BatteryLevel) ? "0" : x.BatteryLevel).ToList(),
                ReadingTime = result.Select(x => x.ReadingTime.ToString()).ToList()
            };
        }
    }
}
