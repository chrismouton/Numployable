using Mediator;
using Numployable.Application.DTOs.NextActions;
using Numployable.Application.Features.NextActions.Requests.Queries;
using Numployable.Application.Mappings;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.NextActions.Handlers.Queries;

public class GetNextActionDetailRequestHandler(INextActionRepository nextActionRepository)
    : IQueryHandler<GetNextActionDetailRequest, NextActionDto>
{
    public async ValueTask<NextActionDto> Handle(GetNextActionDetailRequest request, CancellationToken cancellationToken)
    {
        NextAction? nextAction = await nextActionRepository.Get(request.Id);

        return nextAction.ToNextAction();
    }
}