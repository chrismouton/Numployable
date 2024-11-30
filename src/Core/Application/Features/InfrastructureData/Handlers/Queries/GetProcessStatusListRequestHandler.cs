namespace Numployable.Application.Features.InfrastructureData.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.InfrastructureData;
using Numployable.Application.Features.InfrastructureData.Requests.Queries;
using Persistence.Contracts;
using Domain;

public class GetProcessStatusListRequestHandler(IProcessStatusRepository processStatusRepository, IMapper mapper) 
    : IRequestHandler<GetProcessStatusListRequest, List<ProcessStatusDto>>
{
    public async Task<List<ProcessStatusDto>> Handle(GetProcessStatusListRequest request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<ProcessStatus> processStatusList = await processStatusRepository.GetAll();

        return mapper.Map<List<ProcessStatusDto>>(processStatusList);
    }
}