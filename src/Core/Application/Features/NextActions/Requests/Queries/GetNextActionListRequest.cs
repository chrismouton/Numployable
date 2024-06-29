namespace Numploy.Application.Features.NextActions.Requests.Queries;

using MediatR;
using Numploy.Application.DTOs.NextActions;

public class GetNextActionListRequest : IRequest<List<NextActionDto>>
{

}