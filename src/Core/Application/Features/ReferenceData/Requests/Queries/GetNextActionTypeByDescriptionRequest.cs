using Mediator;
using Numployable.Application.DTOs.ReferenceData;

namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

public class GetNextActionTypeByDescriptionRequest(string description)
    : IQuery<NextActionTypeDto>
{
    public string Description { get; init; } = description;
}