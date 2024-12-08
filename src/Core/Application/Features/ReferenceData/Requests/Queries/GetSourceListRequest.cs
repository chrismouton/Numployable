using MediatR;
using Numployable.Application.DTOs.ReferenceData;

namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

public class GetSourceListRequest : IRequest<List<SourceDto>>
{
}