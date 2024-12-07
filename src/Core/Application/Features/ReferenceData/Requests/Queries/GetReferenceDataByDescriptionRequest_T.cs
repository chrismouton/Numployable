namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

using MediatR;

public class GetReferenceDataByDescriptionRequest<T> : IRequest<T>
{
    public required string Description { get; set; }
}