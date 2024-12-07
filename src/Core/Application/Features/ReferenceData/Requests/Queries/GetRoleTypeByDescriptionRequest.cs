namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

using MediatR;
using Numployable.Application.DTOs.ReferenceData;

public class GetRoleTypeByDescriptionRequest : IRequest<RoleTypeDto>
{
    public required string Description { get; set; }
}