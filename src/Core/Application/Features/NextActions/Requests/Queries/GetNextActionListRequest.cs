using Mediator;
using Numployable.Application.DTOs.NextActions;

namespace Numployable.Application.Features.NextActions.Requests.Queries;

public class GetNextActionListRequest : IQuery<List<NextActionDto>>
{
}