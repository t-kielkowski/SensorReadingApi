using MediatR;
using SensorReading.Application.Dto;
using SensorReading.Infrastructure.Repository.WeightReadings;

namespace SensorReading.Application.Feature.GetTemperatureData
{
    public class GetSensorTempDataQueryHandler : IRequestHandler<GetSensorTempDataQuery, IEnumerable<BeehiveTempDto>>
    {
        private readonly IWeightReadingsRepository _weightReadingsRepository;

        public GetSensorTempDataQueryHandler(IWeightReadingsRepository weightReadingsRepository)
        {
            _weightReadingsRepository = weightReadingsRepository;
        }

        public async Task<IEnumerable<BeehiveTempDto>> Handle(GetSensorTempDataQuery request, CancellationToken cancellationToken)
        {
            var result = await _weightReadingsRepository.GetTempByIdAsync(request.SearchParams).ConfigureAwait(false);

            return result.Select(x => new BeehiveTempDto()
            {
                Temperature = string.IsNullOrEmpty(x.Temperature) ? "0" : x.Temperature,
                ReadingTime = x.ReadingTime.ToString()
            });
        }
    }
}