using MediatR;
using Numployable.Application.DTOs.InfrastructureData;

namespace Numployable.Application.Features.InfrastructureData.Requests.Queries;

public class GetStatusDetailRequest : IRequest<StatusDto>
{
    public int Id { get; set; }
}