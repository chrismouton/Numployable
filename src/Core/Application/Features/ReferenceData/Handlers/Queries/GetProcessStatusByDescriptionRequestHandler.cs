using AutoMapper;
using MediatR;
using Numployable.Application.DTOs.ReferenceData;
using Numployable.Application.Features.ReferenceData.Requests.Queries;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.ReferenceData.Handlers.Queries;

public class GetProcessStatusByDescriptionRequestHandler(
    IProcessStatusRepository processStatusRepository,
    IMapper mapper)
    : IRequestHandler<GetProcessStatusByDescriptionRequest, ProcessStatusDto>
{
    public async Task<ProcessStatusDto> Handle(GetProcessStatusByDescriptionRequest request,
        CancellationToken cancellationToken)
    {
        ProcessStatus? processStatus = await processStatusRepository.GetByDescription(request.Description);

        return mapper.Map<ProcessStatusDto>(processStatus);
    }
}