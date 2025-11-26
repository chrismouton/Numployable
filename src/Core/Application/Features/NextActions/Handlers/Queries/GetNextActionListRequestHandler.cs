using Mediator;
using Numployable.Application.DTOs.NextActions;
using Numployable.Application.Features.NextActions.Requests.Queries;
using Numployable.Application.Mappings;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.NextActions.Handlers.Queries;

public class GetNextActionListRequestHandler(INextActionRepository nextActionRepository)
    : IQueryHandler<GetNextActionListRequest, IEnumerable<NextActionDto>>
{
    public async ValueTask<IEnumerable<NextActionDto>> Handle(GetNextActionListRequest request,
        CancellationToken cancellationToken)
    {
        IReadOnlyCollection<NextAction> nextActions = await nextActionRepository.GetAll();

        return from item in nextActions
            select item.ToNextAction();
    }
}