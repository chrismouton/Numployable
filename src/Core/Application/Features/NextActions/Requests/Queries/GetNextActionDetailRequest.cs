namespace Numploy.Application.Features.NextActions.Requests.Queries;

using MediatR;
using Numploy.Application.DTOs.NextActions;

public class GetNextActionDetailRequest : IRequest<NextActionDto>
{
    public int Id { get; set; }
}