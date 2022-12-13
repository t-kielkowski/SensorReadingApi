namespace SensorReading.Infrastructure.Repository
{
    public interface IBeehiveRepository
    {
        Task<List<string>> BeehiveList();
    }
}
