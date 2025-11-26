using Mediator;
using Numployable.Application.DTOs.NextActions;
using Numployable.Application.Responses;

namespace Numployable.Application.Features.NextActions.Requests.Command;

public class UpdateNextActionCommand : ICommand<BaseCommandResponse>
{
    public int Id { get; set; }

    public UpdateNextActionDto? UpdateNextActionDto { get; set; }
}