using MediatR;
using Numployable.Application.DTOs.ReferenceData;

namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

public class GetSourceByDescriptionRequest : IRequest<SourceDto>
{
    public required string Description { get; set; }
}