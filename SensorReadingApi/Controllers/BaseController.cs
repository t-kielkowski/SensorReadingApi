using MediatR;
using Microsoft.AspNetCore.Mvc;
using SensorReading.Application.Dto;

namespace SensorReading.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator Mediator;

        public BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected WeightReadingsSearchParams CreateSearchParams(string id, DateTime? dateFrom, DateTime? dateTo) => new()
        {
            WeightId = id,
            DateFrom = dateFrom,
            DateTo = dateTo
        };
    }
}
