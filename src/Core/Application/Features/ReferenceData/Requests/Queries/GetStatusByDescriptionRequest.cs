using Mediator;
using Numployable.Application.DTOs.ReferenceData;

namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

public class GetStatusByDescriptionRequest(string description)
    : IQuery<StatusDto>
{
    public string Description { get; init; } = description;
}