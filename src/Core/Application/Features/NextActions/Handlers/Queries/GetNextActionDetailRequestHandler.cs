namespace Numploy.Application.Features.NextActions.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numploy.Application.DTOs.NextActions;
using Numploy.Application.Features.NextActions.Requests.Queries;
using Numploy.Application.Persistence.Contracts;

public class GetNextActionDetailRequestHandler(INextActionRepository NextActionRepository, IMapper mapper) 
    : IRequestHandler<GetNextActionDetailRequest, NextActionDto>
{
    private readonly INextActionRepository _nextActionRepository = NextActionRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<NextActionDto> Handle(GetNextActionDetailRequest request, CancellationToken cancellationToken)
    {
        var NextAction = await _nextActionRepository.Get(request.Id);

        return _mapper.Map<NextActionDto>(NextAction);
    }
}