using MediatR;
using SensorReading.Application.Dto;
using SensorReading.Infrastructure.Repository.WeightReadings;

namespace SensorReading.Application.Feature.GetTemperatureData
{
    public class GetSensorTempDataQueryHandler : IRequestHandler<GetSensorTempDataQuery, BeehiveTempDto>
    {
        private readonly IWeightReadingsRepository _weightReadingsRepository;

        public GetSensorTempDataQueryHandler(IWeightReadingsRepository weightReadingsRepository)
        {
            _weightReadingsRepository = weightReadingsRepository;
        }

        public async Task<BeehiveTempDto> Handle(GetSensorTempDataQuery request, CancellationToken cancellationToken)
        {
            var result = await _weightReadingsRepository.GetTempByIdAsync(request.SearchParams).ConfigureAwait(false);

            return new BeehiveTempDto()
            {
                Temperature = result.Select(x => string.IsNullOrEmpty(x.Temperature) ? "0" : x.Temperature).ToList(),
                ReadingTime = result.Select(x => x.ReadingTime.ToString()).ToList()
            };       
        }
    }
}