namespace Numployable.Application.Features.InfrastructureData.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.InfrastructureData;
using Numployable.Application.Features.InfrastructureData.Requests.Queries;
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