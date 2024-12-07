using Numployable.Domain;

namespace Numployable.Application.DTOs.NextActions;

public class CreateNextActionDto : BaseDto
{
    public required NextActionType NextActionType {get; set; }

    public required string ActionNote { get; set; }

    public DateTime ActionDate { get; set; }
}