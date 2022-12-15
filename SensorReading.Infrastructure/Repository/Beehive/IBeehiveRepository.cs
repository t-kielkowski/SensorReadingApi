namespace SensorReading.Infrastructure.Repository
{
    public interface IBeehiveRepository
    {
        Task<ICollection<string?>> BeehiveList();
    }
}
