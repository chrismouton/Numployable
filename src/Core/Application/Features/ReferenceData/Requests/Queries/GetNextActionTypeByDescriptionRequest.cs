namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

using MediatR;
using Numployable.Application.DTOs.ReferenceData;

public class GetNextActionTypeByDescriptionRequest : IRequest<NextActionTypeDto>
{
    public required string Description { get; set; }
}