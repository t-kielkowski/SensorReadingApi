using MediatR;
using SensorReading.Application.Dto.Beehive;
using SensorReading.Application.Mapping;
using SensorReading.InfrastructureChart.Repository;

namespace SensorReading.Application.Feature.Beehive
{
    public class GetSensorDataQueryHandler : IRequestHandler<GetSensorDataQuery, BeehiveDataDto>
    {
        private readonly ISHT31Repository _sHT31Repository;

        public GetSensorDataQueryHandler(ISHT31Repository sHT31Repository)
        {
            _sHT31Repository = sHT31Repository;
        }

        public async Task<BeehiveDataDto> Handle(GetSensorDataQuery request, CancellationToken cancellationToken)
        {
            var result = await _sHT31Repository.GetAllAsync().ConfigureAwait(false);

            return new BeehiveDataDto
            {
                BeehiveName = "UL_1",
                Temperature = result.Select(x => x.ToTemperatureDto()),
                Moisture = result.Select(x => x.ToMoistureDto())
            };
        }
    }
}
