using MediatR;
using SensorReading.Infrastructure.Repository;

namespace SensorReading.Application.Feature.BeehiveList
{
    internal class GetBeehiveListQueryHandler : IRequestHandler<GetBeehiveListQuery, ICollection<string?>>
    {
        private readonly IBeehiveRepository _beehiveRepository;

        public GetBeehiveListQueryHandler(IBeehiveRepository beehiveRepository)
        {
            _beehiveRepository = beehiveRepository;
        }

        public async Task<ICollection<string?>> Handle(GetBeehiveListQuery request, CancellationToken cancellationToken)
        {
            return await _beehiveRepository.BeehiveList().ConfigureAwait(false);
        }
    }
}
