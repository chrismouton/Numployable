namespace Numployable.Application.Features.NextActions.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.NextActions;
using Numployable.Application.Features.NextActions.Requests.Queries;
using Numployable.Application.Persistence.Contracts;

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