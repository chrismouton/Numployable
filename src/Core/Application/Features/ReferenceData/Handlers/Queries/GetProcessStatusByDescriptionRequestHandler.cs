using AutoMapper;
using Mediator;
using Numployable.Application.DTOs.ReferenceData;
using Numployable.Application.Features.ReferenceData.Requests.Queries;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.ReferenceData.Handlers.Queries;

public class GetProcessStatusByDescriptionRequestHandler(
    IProcessStatusRepository processStatusRepository,
    IMapper mapper)
    : IQueryHandler<GetProcessStatusByDescriptionRequest, ProcessStatusDto>
{
    public async ValueTask<ProcessStatusDto> Handle(GetProcessStatusByDescriptionRequest request,
        CancellationToken cancellationToken)
    {
        ProcessStatus? processStatus = await processStatusRepository.GetByDescription(request.Description);

        return mapper.Map<ProcessStatusDto>(processStatus);
    }
}