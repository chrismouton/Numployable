using Mediator;
using Numployable.Application.DTOs.NextActions;

namespace Numployable.Application.Features.NextActions.Requests.Queries;

public class GetNextActionDetailRequest : IQuery<NextActionDto>
{
    public int Id { get; set; }
}