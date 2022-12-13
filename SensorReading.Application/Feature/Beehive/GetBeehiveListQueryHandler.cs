using MediatR;
using SensorReading.Infrastructure.Repository;

namespace SensorReading.Application.Feature.Beehive
{
    internal class GetBeehiveListQueryHandler : IRequestHandler<GetBeehiveListQuery, List<string>>
    {
        private readonly IBeehiveRepository _beehiveRepository;

        public GetBeehiveListQueryHandler(IBeehiveRepository beehiveRepository)
        {
            _beehiveRepository = beehiveRepository;
        }

        public async Task<List<string>> Handle(GetBeehiveListQuery request, CancellationToken cancellationToken)
        {            
            return await _beehiveRepository.BeehiveList().ConfigureAwait(false);
        }
    }
}
