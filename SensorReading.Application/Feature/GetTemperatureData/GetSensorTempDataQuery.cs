﻿using MediatR;
using SensorReading.Application.Dto;

namespace SensorReading.Application.Feature.GetTemperatureData
{
    public class GetSensorTempDataQuery : IRequest<BeehiveTempDto>
    {
        public WeightReadingsSearchParams SearchParams { get; }

        public GetSensorTempDataQuery(WeightReadingsSearchParams searchParams) => SearchParams = searchParams;
    }
}
