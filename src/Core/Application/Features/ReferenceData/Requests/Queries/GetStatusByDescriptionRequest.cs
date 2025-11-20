using Mediator;
using Numployable.Application.DTOs.ReferenceData;

namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

public class GetStatusByDescriptionRequest : IRequest<StatusDto>
{
    public required string Description { get; set; }
}