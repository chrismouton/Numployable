namespace Numployable.Application.Features.NextActions.Requests.Queries;

using MediatR;
using Numployable.Application.DTOs.NextActions;

public class GetNextActionDetailRequest : IRequest<NextActionDto>
{
    public int Id { get; set; }
}