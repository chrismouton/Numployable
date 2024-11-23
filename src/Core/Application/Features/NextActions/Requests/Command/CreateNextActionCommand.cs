using MediatR;
using Numployable.Application.DTOs.NextActions;
using Numployable.Application.Responses;

namespace Numployable.Application.Features.NextActions.Requests.Commands;

public class CreateNextActionCommand : IRequest<BaseCommandResponse>
{
    public CreateNextActionDto? CreateNextActionDto { get; set; }
}