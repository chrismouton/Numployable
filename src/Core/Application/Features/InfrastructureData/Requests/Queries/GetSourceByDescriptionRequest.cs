namespace Numployable.Application.Features.InfrastructureData.Requests.Queries;

using MediatR;
using Numployable.Application.DTOs.InfrastructureData;

public class GetSourceByDescriptionRequest : IRequest<SourceDto>
{
    public required string Description { get; set; }
}