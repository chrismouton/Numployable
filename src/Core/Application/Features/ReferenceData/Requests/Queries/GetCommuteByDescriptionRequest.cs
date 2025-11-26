using Mediator;
using Numployable.Application.DTOs.ReferenceData;

namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

public class GetCommuteByDescriptionRequest(string description)
    : IQuery<CommuteDto>
{
    public string Description { get; init; } = description;
}