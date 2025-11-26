using AutoMapper;
using Mediator;
using Numployable.Application.DTOs.ReferenceData;
using Numployable.Application.Features.ReferenceData.Requests.Queries;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.ReferenceData.Handlers.Queries;

public class GetCommuteByDescriptionRequestHandler(ICommuteRepository commuteRepository, IMapper mapper)
    : IQueryHandler<GetCommuteByDescriptionRequest, CommuteDto>
{
    public async ValueTask<CommuteDto> Handle(GetCommuteByDescriptionRequest request, CancellationToken cancellationToken)
    {
        Commute? commute = await commuteRepository.GetByDescription(request.Description);

        return mapper.Map<CommuteDto>(commute);
    }
}