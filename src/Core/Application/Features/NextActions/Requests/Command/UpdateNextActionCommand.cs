using MediatR;
using Numployable.Application.DTOs.NextActions;
using Numployable.Application.Responses;

namespace Numployable.Application.Features.NextActions.Requests.Commands;

public class UpdateNextActionCommand : IRequest<BaseCommandResponse>
{
    public int Id { get; set; }

    public UpdateNextActionDto? UpdateNextActionDto { get; set; }
}