using Mediator;

namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

public class GetReferenceDataByDescriptionRequest<T> : IRequest<T>
{
    public required string Description { get; set; }
}