using MediatR;
using Numployable.Application.DTOs.NextActions;

namespace Numployable.Application.Features.NextActions.Requests.Queries;

public class GetNextActionDetailRequest : IRequest<NextActionDto>
{
    public int Id { get; set; }
}