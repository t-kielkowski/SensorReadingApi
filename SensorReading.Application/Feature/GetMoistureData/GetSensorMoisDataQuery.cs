using MediatR;
using SensorReading.Application.Dto;

namespace SensorReading.Application.Feature.GetMoistureData
{
    public class GetSensorMoisDataQuery : IRequest<IEnumerable<BeehiveMoisDto>>
    {
        public WeightReadingsSearchParams SearchParams { get; }

        public GetSensorMoisDataQuery(WeightReadingsSearchParams searchParams) => SearchParams = searchParams;
    }
}
