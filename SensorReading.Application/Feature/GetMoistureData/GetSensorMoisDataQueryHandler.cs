using MediatR;
using SensorReading.Application.Dto;
using SensorReading.Infrastructure.Repository.WeightReadings;

namespace SensorReading.Application.Feature.GetMoistureData
{
    public class GetSensorMoisDataQueryHandler : IRequestHandler<GetSensorMoisDataQuery, BeehiveMoisDto>
    {
        private readonly IWeightReadingsRepository _weightReadingsRepository;

        public GetSensorMoisDataQueryHandler(IWeightReadingsRepository weightReadingsRepository)
        {
            _weightReadingsRepository = weightReadingsRepository;
        }

        public async Task<BeehiveMoisDto> Handle(GetSensorMoisDataQuery request, CancellationToken cancellationToken)
        {
            var result = await _weightReadingsRepository.GetMoisByIdAsync(request.SearchParams).ConfigureAwait(false);         

            return new BeehiveMoisDto()
            {
                Moisture = result.Select(x => string.IsNullOrEmpty(x.Moisture) ? "0" : x.Moisture).ToList(),
                ReadingTime = result.Select(x => x.ReadingTime.ToString()).ToList()
            };
        }
    }
}
