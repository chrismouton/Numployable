namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

using MediatR;
using Numployable.Application.DTOs.ReferenceData;

public class GetCommuteByDescriptionRequest : IRequest<CommuteDto>
{
    public required string Description { get; set; }
}