using MediatR;
namespace SensorReading.Application.Feature.Beehive
{
    public class GetBeehiveListQuery : IRequest<List<string>>
    {
    }
}
