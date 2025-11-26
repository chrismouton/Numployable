using AutoMapper;
using Mediator;
using Numployable.Application.DTOs.ReferenceData;
using Numployable.Application.Features.ReferenceData.Requests.Queries;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.ReferenceData.Handlers.Queries;

public class GetProcessStatusListRequestHandler(IProcessStatusRepository processStatusRepository, IMapper mapper)
    : IQueryHandler<GetProcessStatusListRequest, IEnumerable<ProcessStatusDto>>
{
    public async ValueTask<IEnumerable<ProcessStatusDto>> Handle(GetProcessStatusListRequest request,
        CancellationToken cancellationToken)
    {
        IReadOnlyCollection<ProcessStatus> processStatusList = await processStatusRepository.GetAll();

        return mapper.Map<IEnumerable<ProcessStatusDto>>(processStatusList);
    }
}