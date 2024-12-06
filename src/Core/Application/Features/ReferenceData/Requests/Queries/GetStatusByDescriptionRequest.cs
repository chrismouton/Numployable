namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

using MediatR;
using Numployable.Application.DTOs.ReferenceData;

public class GetStatusByDescriptionRequest : IRequest<StatusDto>
{
    public required string Description { get; set; }
}