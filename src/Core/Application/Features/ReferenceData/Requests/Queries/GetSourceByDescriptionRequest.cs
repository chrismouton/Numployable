using Mediator;
using Numployable.Application.DTOs.ReferenceData;

namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

public class GetSourceByDescriptionRequest(string description)
    : IQuery<SourceDto>
{
    public string Description { get; init; } = description;
}