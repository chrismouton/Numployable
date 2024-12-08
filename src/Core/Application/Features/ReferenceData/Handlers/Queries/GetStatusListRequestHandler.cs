using AutoMapper;
using MediatR;
using Numployable.Application.DTOs.ReferenceData;
using Numployable.Application.Features.ReferenceData.Requests.Queries;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.ReferenceData.Handlers.Queries;

public class GetStatusListRequestHandler(IStatusRepository statusRepository, IMapper mapper)
    : IRequestHandler<GetStatusListRequest, IEnumerable<StatusDto>>
{
    public async Task<IEnumerable<StatusDto>> Handle(GetStatusListRequest request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Status> statusList = await statusRepository.GetAll();

        return mapper.Map<IEnumerable<StatusDto>>(statusList);
    }
}