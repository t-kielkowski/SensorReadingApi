using MediatR;
using Microsoft.AspNetCore.Mvc;
using SensorReading.Application.Dto;
using SensorReading.Application.Feature.BeehiveList;
using SensorReading.Application.Feature.GetBatteryLevel;
using SensorReading.Application.Feature.GetMoistureData;
using SensorReading.Application.Feature.GetTemperatureData;
using SensorReading.Application.Feature.GetWeightData;

namespace SensorReading.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeehiveController : BaseController
    {
        private const string _mandatoryParameter = "Id is mandatory";

        public BeehiveController(IMediator mediator) : base(mediator)
        {}

        [HttpGet]
        [Route("beehiveList", Name = "GetBeehiveList")]
        public async Task<ICollection<string?>> GetBeehiveList()
        {
            var command = new GetBeehiveListQuery();
            return await Mediator.Send(command).ConfigureAwait(false);
        }

        [HttpGet]
        [Route("temperature", Name = "GetTempData")]    
        public async Task<BeehiveTempDto> GetTemperatureData([FromQuery] string id, [FromQuery] DateTime? dateFrom, [FromQuery] DateTime? dateTo)
        {
            if (string.IsNullOrEmpty(id))
                throw new BadHttpRequestException(_mandatoryParameter);

            var searchParams = CreateSearchParams(id, dateFrom, dateTo);
            var command = new GetSensorTempDataQuery(searchParams);

            return await Mediator.Send(command).ConfigureAwait(false);
        }

        [HttpGet]
        [Route("moisture", Name = "GetMoisData")]
        public async Task<BeehiveMoisDto> GetMoistureData([FromQuery] string id, [FromQuery] DateTime? dateFrom, [FromQuery] DateTime? dateTo)
        {
            if (string.IsNullOrEmpty(id))
                throw new BadHttpRequestException(_mandatoryParameter);

            var searchParams = CreateSearchParams(id, dateFrom, dateTo);
            var command = new GetSensorMoisDataQuery(searchParams);

            return  await Mediator.Send(command).ConfigureAwait(false);
        }

        [HttpGet]
        [Route("weight", Name = "GetWeightData")]
        public async Task<BeehiveWeightDto> GetWeightData([FromQuery] string id, [FromQuery] DateTime? dateFrom, [FromQuery] DateTime? dateTo)
        {
            if (string.IsNullOrEmpty(id))
                throw new BadHttpRequestException(_mandatoryParameter);

            var searchParams = CreateSearchParams(id, dateFrom, dateTo);
            var command = new GetSensorWeightDataQuery(searchParams);

            return await Mediator.Send(command).ConfigureAwait(false);
        }

        [HttpGet]
        [Route("baterryLevel", Name = "GetBaterryLevel")]
        public async Task<BeehiveBatteryLevelDto> GetBaterryLevel([FromQuery] string id, [FromQuery] DateTime? dateFrom, [FromQuery] DateTime? dateTo)
        {
            if (string.IsNullOrEmpty(id))
                throw new BadHttpRequestException(_mandatoryParameter);

            var searchParams = CreateSearchParams(id, dateFrom, dateTo);         
            var command = new GetBatteryLevelQuery(searchParams);

            return await Mediator.Send(command).ConfigureAwait(false);
        }       
    }
}