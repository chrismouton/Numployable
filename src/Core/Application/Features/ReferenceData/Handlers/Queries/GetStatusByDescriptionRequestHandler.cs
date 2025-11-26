using AutoMapper;
using Mediator;
using Numployable.Application.DTOs.ReferenceData;
using Numployable.Application.Features.ReferenceData.Requests.Queries;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.ReferenceData.Handlers.Queries;

public class GetStatusByDescriptionRequestHandler(IStatusRepository statusRepository, IMapper mapper)
    : IQueryHandler<GetStatusByDescriptionRequest, StatusDto>
{
    public async ValueTask<StatusDto> Handle(GetStatusByDescriptionRequest request, CancellationToken cancellationToken)
    {
        Status? status = await statusRepository.GetByDescription(request.Description);

        return mapper.Map<StatusDto>(status);
    }
}