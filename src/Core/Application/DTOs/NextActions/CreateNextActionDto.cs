using Numployable.Application.DTOs.Common;
using Numployable.Domain;

namespace Numployable.Application.DTOs.NextActions;

public class CreateNextActionDto : BaseDto
{
    public NextActionType? NextActionType {get; set; }

    public string? ActionNote { get; set; }

    public DateTime? ActionDate { get; set; }
}