using MediatR;
using Numployable.Application.DTOs.InfrastructureData;

namespace Numployable.Application.Features.InfrastructureData.Requests.Queries;

public class GetRoleTypeListRequest : IRequest<List<RoleTypeDto>>
{
}