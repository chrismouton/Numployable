using MediatR;
using Numployable.Application.DTOs.NextActions;
using Numployable.Application.Features.NextActions.Requests.Queries;
using Numployable.Application.Mappings;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.NextActions.Handlers.Queries;

public class GetNextActionDetailRequestHandler(INextActionRepository nextActionRepository)
    : IRequestHandler<GetNextActionDetailRequest, NextActionDto>
{
    public async Task<NextActionDto> Handle(GetNextActionDetailRequest request, CancellationToken cancellationToken)
    {
        NextAction? nextAction = await nextActionRepository.Get(request.Id);

        return nextAction.ToNextAction();
    }
}