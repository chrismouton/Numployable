namespace Numployable.Application.Features.InfrastructureData.Requests.Queries;

using MediatR;
using Numployable.Application.DTOs.InfrastructureData;

public class GetStatusByDescriptionRequest : IRequest<StatusDto>
{
    public required string Description { get; set; }
}