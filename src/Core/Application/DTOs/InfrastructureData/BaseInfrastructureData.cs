using Numployable.Application.DTOs.Common;

namespace Numployable.Application.DTOs.InfrastructureData;

public abstract class BaseInfrastructureDataDto : BaseDto
{
    public string Description { get; set; } = null!;
}
