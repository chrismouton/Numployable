namespace Numployable.Application.Features.ReferenceData.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.ReferenceData;
using Numployable.Application.Features.ReferenceData.Requests.Queries;
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