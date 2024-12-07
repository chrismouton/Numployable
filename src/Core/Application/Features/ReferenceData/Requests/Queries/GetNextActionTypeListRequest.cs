namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

using MediatR;
using Numployable.Application.DTOs.ReferenceData;

public class GetNextActionTypeListRequest : IRequest<List<NextActionTypeDto>>
{
}