using AutoMapper;
using Mediator;
using Numployable.Application.DTOs.ReferenceData;
using Numployable.Application.Features.ReferenceData.Requests.Queries;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.ReferenceData.Handlers.Queries;

public class GetCommuteListRequestHandler(ICommuteRepository commuteRepository, IMapper mapper)
    : IRequestHandler<GetCommuteListRequest, IEnumerable<CommuteDto>>
{
    public async ValueTask<IEnumerable<CommuteDto>> Handle(GetCommuteListRequest request,
        CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Commute> commuteList = await commuteRepository.GetAll();

        return mapper.Map<IEnumerable<CommuteDto>>(commuteList);
    }
}