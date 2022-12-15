using MediatR;
using SensorReading.Application.Dto;

namespace SensorReading.Application.Feature.GetWeightData
{
    public class GetSensorWeightDataQuery : IRequest<IEnumerable<BeehiveWeightDto>>
    {
        public WeightReadingsSearchParams SearchParams { get; }

        public GetSensorWeightDataQuery(WeightReadingsSearchParams searchParams) => SearchParams = searchParams;    
    }
}
