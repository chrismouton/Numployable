using Mediator;

namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

public abstract class GetReferenceDataByDescriptionRequest<T>(string description)
    : IQuery<T>
{
    public string Description { get; init; } = description;
}