namespace Numployable.Application.Features.InfrastructureData.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.InfrastructureData;
using Numployable.Application.Features.InfrastructureData.Requests.Queries;
using Persistence.Contracts;
using Domain;

public class GetStatusListRequestHandler(IStatusRepository StatusRepository, IMapper mapper) 
    : IRequestHandler<GetStatusListRequest, List<StatusDto>>
{
    private readonly IStatusRepository _StatusRepository = StatusRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<StatusDto>> Handle(GetStatusListRequest request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Status> Statuss = await _StatusRepository.GetAll();

        return _mapper.Map<List<StatusDto>>(Statuss);
    }
}