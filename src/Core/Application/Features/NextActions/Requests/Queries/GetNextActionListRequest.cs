namespace Numployable.Application.Features.NextActions.Requests.Queries;

using MediatR;
using Numployable.Application.DTOs.NextActions;

public class GetNextActionListRequest : IRequest<List<NextActionDto>>
{

}