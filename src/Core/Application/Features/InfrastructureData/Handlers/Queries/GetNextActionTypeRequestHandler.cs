namespace Numployable.Application.Features.InfrastructureData.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.InfrastructureData;
using Numployable.Application.Features.InfrastructureData.Requests.Queries;
using Persistence.Contracts;
using Domain;

public class GetNextActionTypeListRequestHandler(INextActionTypeRepository NextActionTypeRepository, IMapper mapper) 
    : IRequestHandler<GetNextActionTypeListRequest, List<NextActionTypeDto>>
{
    private readonly INextActionTypeRepository _NextActionTypeRepository = NextActionTypeRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<NextActionTypeDto>> Handle(GetNextActionTypeListRequest request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<NextActionType> NextActionTypes = await _NextActionTypeRepository.GetAll();

        return _mapper.Map<List<NextActionTypeDto>>(NextActionTypes);
    }
}