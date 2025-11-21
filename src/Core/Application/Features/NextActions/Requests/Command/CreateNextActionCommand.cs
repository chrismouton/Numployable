using Mediator;
using Numployable.Application.DTOs.NextActions;
using Numployable.Application.Responses;

namespace Numployable.Application.Features.NextActions.Requests.Command;

public class CreateNextActionCommand : ICommand<BaseCommandResponse>
{
    public CreateNextActionDto? CreateNextActionDto { get; set; }
}