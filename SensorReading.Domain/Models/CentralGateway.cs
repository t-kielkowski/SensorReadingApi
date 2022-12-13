using System;
using System.Collections.Generic;

namespace SensorReading.Domain.Models;

public partial class CentralGateway
{
    public uint Id { get; set; }

    public string? GatewayId { get; set; }

    public string? Sht31Temperature { get; set; }

    public string? Sht31Moisture { get; set; }

    public string? Bmp280Temperature { get; set; }

    public string? Bmp280Pressure { get; set; }

    public string? Bh1750Luks { get; set; }

    public string? SoilMoisture { get; set; }

    public string? BatteryLevel { get; set; }

    public DateTime ReadingTime { get; set; }

    public virtual GatewayInformation? Gateway { get; set; }
}
