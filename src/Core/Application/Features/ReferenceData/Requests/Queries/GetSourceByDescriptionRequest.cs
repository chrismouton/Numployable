namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

using MediatR;
using Numployable.Application.DTOs.ReferenceData;

public class GetSourceByDescriptionRequest : IRequest<SourceDto>
{
    public required string Description { get; set; }
}