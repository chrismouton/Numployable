namespace Numployable.Application.Features.ReferenceData.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.ReferenceData;
using Numployable.Application.Features.ReferenceData.Requests.Queries;
using Persistence.Contracts;
using Domain;

public class GetStatusListRequestHandler(IStatusRepository statusRepository, IMapper mapper) 
    : IRequestHandler<GetStatusListRequest, List<StatusDto>>
{
    public async Task<List<StatusDto>> Handle(GetStatusListRequest request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Status> statusList = await statusRepository.GetAll();

        return mapper.Map<List<StatusDto>>(statusList);
    }
}