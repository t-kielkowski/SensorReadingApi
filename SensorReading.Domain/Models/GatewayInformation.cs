namespace SensorReading.Domain.Models;

public partial class GatewayInformation
{
    public string GatewayId { get; set; } = null!;

    public string? Longitude { get; set; }

    public string? Latitude { get; set; }

    public DateOnly? InstallationDate { get; set; }

    public virtual ICollection<CentralGateway> CentralGateways { get; } = new List<CentralGateway>();
}
