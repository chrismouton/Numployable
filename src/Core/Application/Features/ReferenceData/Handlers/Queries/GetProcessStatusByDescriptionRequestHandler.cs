namespace Numployable.Application.Features.ReferenceData.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.ReferenceData;
using Numployable.Application.Features.ReferenceData.Requests.Queries;
using Persistence.Contracts;
using Domain;

public class GetProcessStatusByDescriptionRequestHandler(IProcessStatusRepository processStatusRepository, IMapper mapper) 
    : IRequestHandler<GetProcessStatusByDescriptionRequest, ProcessStatusDto>
{
    public async Task<ProcessStatusDto> Handle(GetProcessStatusByDescriptionRequest request, CancellationToken cancellationToken)
    {
        ProcessStatus processStatus = await processStatusRepository.GetByDescription(request.Description);

        return mapper.Map<ProcessStatusDto>(processStatus);
    }
}