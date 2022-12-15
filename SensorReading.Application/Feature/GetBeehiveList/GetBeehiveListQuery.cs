using MediatR;

namespace SensorReading.Application.Feature.BeehiveList
{
    public class GetBeehiveListQuery : IRequest<ICollection<string?>>
    {
    }
}
