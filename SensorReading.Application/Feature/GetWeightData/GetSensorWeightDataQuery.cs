using MediatR;
using SensorReading.Application.Dto;

namespace SensorReading.Application.Feature.GetWeightData
{
    public class GetSensorWeightDataQuery : IRequest<BeehiveWeightDto>
    {
        public WeightReadingsSearchParams SearchParams { get; }

        public GetSensorWeightDataQuery(WeightReadingsSearchParams searchParams) => SearchParams = searchParams;    
    }
}
