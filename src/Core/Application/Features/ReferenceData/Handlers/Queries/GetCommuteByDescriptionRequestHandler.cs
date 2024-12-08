using AutoMapper;
using MediatR;
using Numployable.Application.DTOs.ReferenceData;
using Numployable.Application.Features.ReferenceData.Requests.Queries;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.ReferenceData.Handlers.Queries;

public class GetCommuteByDescriptionRequestHandler(ICommuteRepository commuteRepository, IMapper mapper)
    : IRequestHandler<GetCommuteByDescriptionRequest, CommuteDto>
{
    public async Task<CommuteDto> Handle(GetCommuteByDescriptionRequest request, CancellationToken cancellationToken)
    {
        Commute? commute = await commuteRepository.GetByDescription(request.Description);

        return mapper.Map<CommuteDto>(commute);
    }
}