using AutoMapper;
using MediatR;
using Numployable.Application.DTOs.InfrastructureData;
using Numployable.Application.Features.InfrastructureData.Requests.Queries;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.InfrastructureData.Handlers.Queries;

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