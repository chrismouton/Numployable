namespace Numployable.Application.Features.NextActions.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.NextActions;
using Numployable.Application.Features.NextActions.Requests.Queries;
using Persistence.Contracts;
using Domain;

public class GetNextActionListRequestHandler(INextActionRepository NextActionRepository, IMapper mapper) 
    : IRequestHandler<GetNextActionListRequest, List<NextActionDto>>
{
    private readonly INextActionRepository _nextActionRepository = NextActionRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<NextActionDto>> Handle(GetNextActionListRequest request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<NextAction> NextActions = await _nextActionRepository.GetAll();

        return _mapper.Map<List<NextActionDto>>(NextActions);
    }
}