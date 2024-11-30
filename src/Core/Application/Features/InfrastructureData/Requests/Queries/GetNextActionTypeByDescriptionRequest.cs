namespace Numployable.Application.Features.InfrastructureData.Requests.Queries;

using MediatR;
using Numployable.Application.DTOs.InfrastructureData;

public class GetNextActionTypeByDescriptionRequest : IRequest<NextActionTypeDto>
{
    public required string Description { get; set; }
}