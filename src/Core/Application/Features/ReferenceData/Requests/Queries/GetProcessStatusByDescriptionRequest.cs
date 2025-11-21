using Mediator;
using Numployable.Application.DTOs.ReferenceData;

namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

public class GetProcessStatusByDescriptionRequest(string description)
    : IQuery<ProcessStatusDto>  
{
    public string Description { get; init; } = description;
}