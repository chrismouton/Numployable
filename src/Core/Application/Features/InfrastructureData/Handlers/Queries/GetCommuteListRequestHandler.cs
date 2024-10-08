namespace Numployable.Application.Features.InfrastructureData.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Application.DTOs.InfrastructureData;
using Application.Features.InfrastructureData.Requests.Queries;
using Domain;
using Persistence.Contracts;

public class GetCommuteListRequestHandler(ICommuteRepository commuteRepository, IMapper mapper) 
    : IRequestHandler<GetCommuteListRequest, List<CommuteDto>>
{
    private readonly ICommuteRepository _commuteRepository = commuteRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<CommuteDto>> Handle(GetCommuteListRequest request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Commute> commuteList = await _commuteRepository.GetAll();

        return _mapper.Map<List<CommuteDto>>(commuteList);
    }
}