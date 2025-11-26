using Mediator;
using Numployable.Application.DTOs.ReferenceData;

namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

public class GetRoleTypeListRequest : IQuery<IEnumerable<RoleTypeDto>>
{
}