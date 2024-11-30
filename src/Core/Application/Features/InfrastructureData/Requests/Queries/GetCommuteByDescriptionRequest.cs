namespace Numployable.Application.Features.InfrastructureData.Requests.Queries;

using MediatR;
using Numployable.Application.DTOs.InfrastructureData;

public class GetCommuteByDescriptionRequest : IRequest<CommuteDto>
{
    public required string Description { get; set; }
}