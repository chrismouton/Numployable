using Mediator;
using Numployable.Application.DTOs.ReferenceData;

namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

public class GetRoleTypeByDescriptionRequest : IRequest<RoleTypeDto>
{
    public required string Description { get; set; }
}