namespace Numployable.Application.Features.InfrastructureData.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.InfrastructureData;
using Numployable.Application.Features.InfrastructureData.Requests.Queries;
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