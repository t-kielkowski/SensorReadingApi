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
        public BeehiveController(IMediator mediator) : base(mediator)
        {}

        [HttpGet]
        [Route("beehiveList", Name = "GetBeehiveList")]
        public async Task<ICollection<string?>> GetBeehiveList()
        {
            var command = new GetBeehiveListQuery();
            var result = await Mediator.Send(command).ConfigureAwait(false);
            return result;
        }

        [HttpGet]
        [Route("temperature", Name = "GetTempData")]    
        public async Task<IEnumerable<BeehiveTempDto>> GetTemperatureData([FromQuery] string id, [FromQuery] DateTime? dateFrom, [FromQuery] DateTime? dateTo)
        {
            if (string.IsNullOrEmpty(id))
                throw new BadHttpRequestException("Id is mandatory");

            var searchParams = new WeightReadingsSearchParams
            {
                WeightId = id,
                DateFrom = dateFrom,
                DateTo = dateTo
            };

            var command = new GetSensorTempDataQuery(searchParams);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            return result;
        }

        [HttpGet]
        [Route("moisture", Name = "GetMoisData")]
        public async Task<IEnumerable<BeehiveMoisDto>> GetMoistureData([FromQuery] string id, [FromQuery] DateTime? dateFrom, [FromQuery] DateTime? dateTo)
        {
            if (string.IsNullOrEmpty(id))
                throw new BadHttpRequestException("Id is mandatory");

            var searchParams = new WeightReadingsSearchParams
            {
                WeightId = id,
                DateFrom = dateFrom,
                DateTo = dateTo
            };

            var command = new GetSensorMoisDataQuery(searchParams);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            return result;
        }

        [HttpGet]
        [Route("weight", Name = "GetWeightData")]
        public async Task<IEnumerable<BeehiveWeightDto>> GetWeightData([FromQuery] string id, [FromQuery] DateTime? dateFrom, [FromQuery] DateTime? dateTo)
        {
            if (string.IsNullOrEmpty(id))
                throw new BadHttpRequestException("Id is mandatory");

            var searchParams = new WeightReadingsSearchParams
            {
                WeightId = id,
                DateFrom = dateFrom,
                DateTo = dateTo
            };

            var command = new GetSensorWeightDataQuery(searchParams);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            return result;
        }

        [HttpGet]
        [Route("baterryLevel", Name = "GetBaterryLevel")]
        public async Task<IEnumerable<BeehiveBatteryLevelDto>> GetBaterryLevel([FromQuery] string id, [FromQuery] DateTime? dateFrom, [FromQuery] DateTime? dateTo)
        {
            if (string.IsNullOrEmpty(id))
                throw new BadHttpRequestException("Id is mandatory");

            var searchParams = new WeightReadingsSearchParams
            {
                WeightId = id,
                DateFrom = dateFrom,
                DateTo = dateTo
            };

            var command = new GetBatteryLevelQuery(searchParams);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            return result;
        }
    }
}