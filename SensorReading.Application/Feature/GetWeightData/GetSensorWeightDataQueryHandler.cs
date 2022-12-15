using MediatR;
using SensorReading.Application.Dto;
using SensorReading.Infrastructure.Repository.WeightReadings;

namespace SensorReading.Application.Feature.GetWeightData
{
    internal class GetSensorWeightDataQueryHandler : IRequestHandler<GetSensorWeightDataQuery, IEnumerable<BeehiveWeightDto>>
    {
        private readonly IWeightReadingsRepository _weightReadingsRepository;

        public GetSensorWeightDataQueryHandler(IWeightReadingsRepository weightReadingsRepository)
        {
            _weightReadingsRepository = weightReadingsRepository;
        }

        public async Task<IEnumerable<BeehiveWeightDto>> Handle(GetSensorWeightDataQuery request, CancellationToken cancellationToken)
        {
            var result = await _weightReadingsRepository.GetWeightByIdAsync(request.SearchParams).ConfigureAwait(false);

            return result.Select(x => new BeehiveWeightDto()
            {
                Weight = string.IsNullOrEmpty(x.Weight) ? "0" : x.Weight,
                ReadingTime = x.ReadingTime.ToString()
            });
        }
    }
}
