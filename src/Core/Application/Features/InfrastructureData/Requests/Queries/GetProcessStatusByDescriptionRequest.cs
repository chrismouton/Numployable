namespace Numployable.Application.Features.InfrastructureData.Requests.Queries;

using MediatR;
using Numployable.Application.DTOs.InfrastructureData;

public class GetProcessStatusByDescriptionRequest : IRequest<ProcessStatusDto>
{
    public required string Description { get; set; }
}