namespace Numploy.Application.Features.NextActions.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numploy.Application.DTOs.NextActions;
using Numploy.Application.Features.NextActions.Requests.Queries;
using Numploy.Application.Persistence.Contracts;
using Numploy.Domain;

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