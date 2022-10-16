using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetSensorDataForGivenBeehive(int id)
        {
            var command = new GetSensorDataQuery(id);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            return (IActionResult)result;
        }
    }
}
