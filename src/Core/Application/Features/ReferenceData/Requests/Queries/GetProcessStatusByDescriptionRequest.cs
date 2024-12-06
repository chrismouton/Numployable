namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

using MediatR;
using Numployable.Application.DTOs.ReferenceData;

public class GetProcessStatusByDescriptionRequest : IRequest<ProcessStatusDto>
{
    public required string Description { get; set; }
}