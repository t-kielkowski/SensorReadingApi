using System;
using System.Collections.Generic;

namespace SensorReading.Domain.Models;

public partial class WeightReading
{
    public uint Id { get; set; }

    public string? WeightId { get; set; }

    public string? Weight { get; set; }

    public string? Temperature { get; set; }

    public string? Moisture { get; set; }

    public string? BatteryLevel { get; set; }

    public DateTime ReadingTime { get; set; }
}
