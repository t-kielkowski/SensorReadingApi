using MediatR;
using SensorReading.Application.Dto;
using SensorReading.Infrastructure.Repository.WeightReadings;

namespace SensorReading.Application.Feature.GetMoistureData
{
    public class GetSensorMoisDataQueryHandler : IRequestHandler<GetSensorMoisDataQuery, IEnumerable<BeehiveMoisDto>>
    {
        private readonly IWeightReadingsRepository _weightReadingsRepository;

        public GetSensorMoisDataQueryHandler(IWeightReadingsRepository weightReadingsRepository)
        {
            _weightReadingsRepository = weightReadingsRepository;
        }

        public async Task<IEnumerable<BeehiveMoisDto>> Handle(GetSensorMoisDataQuery request, CancellationToken cancellationToken)
        {
            var result = await _weightReadingsRepository.GetMoisByIdAsync(request.SearchParams).ConfigureAwait(false);

            return result.Select(x => new BeehiveMoisDto()
            {
                Moisture = string.IsNullOrEmpty(x.Moisture) ? "0" : x.Moisture,
                ReadingTime = x.ReadingTime.ToString()
            });
        }
    }
}
