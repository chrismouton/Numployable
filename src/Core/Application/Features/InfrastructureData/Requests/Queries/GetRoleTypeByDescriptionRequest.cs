namespace Numployable.Application.Features.InfrastructureData.Requests.Queries;

using MediatR;
using Numployable.Application.DTOs.InfrastructureData;

public class GetRoleTypeByDescriptionRequest : IRequest<RoleTypeDto>
{
    public required string Description { get; set; }
}