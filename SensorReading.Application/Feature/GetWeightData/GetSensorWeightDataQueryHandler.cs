using MediatR;
using SensorReading.Application.Dto;
using SensorReading.Infrastructure.Repository.WeightReadings;

namespace SensorReading.Application.Feature.GetWeightData
{
    internal class GetSensorWeightDataQueryHandler : IRequestHandler<GetSensorWeightDataQuery, BeehiveWeightDto>
    {
        private readonly IWeightReadingsRepository _weightReadingsRepository;

        public GetSensorWeightDataQueryHandler(IWeightReadingsRepository weightReadingsRepository)
        {
            _weightReadingsRepository = weightReadingsRepository;
        }

        public async Task<BeehiveWeightDto> Handle(GetSensorWeightDataQuery request, CancellationToken cancellationToken)
        {
            var result = await _weightReadingsRepository.GetWeightByIdAsync(request.SearchParams).ConfigureAwait(false);

            return new BeehiveWeightDto()
            {
                Weight = result.Select(x => string.IsNullOrEmpty(x.Weight) ? "0" : x.Weight).ToList(),
                ReadingTime = result.Select(x => x.ReadingTime.ToString()).ToList()
            };
        }
    }
}
