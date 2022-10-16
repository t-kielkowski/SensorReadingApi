using MediatR;
using SensorReading.Application.Dto.Beehive;

namespace SensorReading.Application.Feature.Beehive
{
    public  class GetSensorDataQuery : IRequest<BeehiveDataDto>
    {
        public int Id { get; set; }

        public GetSensorDataQuery(int id) => Id = id;        
    }
}
