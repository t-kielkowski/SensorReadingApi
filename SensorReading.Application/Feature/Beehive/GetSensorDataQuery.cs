using MediatR;
using SensorReading.Application.Dto.Beehive;

namespace SensorReading.Application.Feature.Beehive
{
    public  class GetSensorDataQuery : IRequest<BeehiveDataDto>
    {
        public string Id { get; set; }

        public GetSensorDataQuery(string id) => Id = id;        
    }
}
