using MediatR;
using Numployable.Application.DTOs.ReferenceData;

namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

public class GetNextActionTypeByDescriptionRequest : IRequest<NextActionTypeDto>
{
    public required string Description { get; set; }
}