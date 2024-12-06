namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

using MediatR;
using Numployable.Application.DTOs.ReferenceData;

public class GetRoleTypeListRequest : IRequest<List<RoleTypeDto>>
{
}