using Mediator;
using Numployable.Application.DTOs.ReferenceData;

namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

public class GetRoleTypeByDescriptionRequest(string description)
    : IQuery<RoleTypeDto>
{
    public string Description { get; init; } = description;
}