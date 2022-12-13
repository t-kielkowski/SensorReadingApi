using MediatR;
using Microsoft.AspNetCore.Mvc;
using SensorReading.Application.Dto.Beehive;
using SensorReading.Application.Feature.Beehive;

namespace SensorReading.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeehiveController : BaseController
    {
        public BeehiveController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("get", Name = "GetSensorData")]    
        public async Task<BeehiveDataDto> GetSensorDataForGivenBeehive(string id)
        {
            var command = new GetSensorDataQuery(id);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            return result;
        }

        [HttpGet]
        [Route("get", Name = "GetBeehiveList")]
        public async Task<List<string>> GetBeehiveList()
        {
            var command = new GetBeehiveListQuery();
            var result = await Mediator.Send(command).ConfigureAwait(false);
            return result;
        }
    }
}