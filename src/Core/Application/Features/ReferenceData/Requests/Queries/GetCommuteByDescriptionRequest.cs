using MediatR;
using Numployable.Application.DTOs.ReferenceData;

namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

public class GetCommuteByDescriptionRequest : IRequest<CommuteDto>
{
    public required string Description { get; set; }
}