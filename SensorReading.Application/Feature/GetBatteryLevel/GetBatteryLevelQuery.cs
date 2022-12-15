using MediatR;
using SensorReading.Application.Dto;
namespace SensorReading.Application.Feature.GetBatteryLevel
{
    public class GetBatteryLevelQuery : IRequest<IEnumerable<BeehiveBatteryLevelDto>>
    {
        public WeightReadingsSearchParams SearchParams { get; }

        public GetBatteryLevelQuery(WeightReadingsSearchParams searchParams) => SearchParams = searchParams;
    }
}
