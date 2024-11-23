using Numployable.Application.Persistence.Contracts;

namespace Numployable.Application.DTOs.InfrastructureData.Validators;

public class CommuteDtoValidator(IInfrastructureDataRepository<CommuteDto> infrastructureDataRepository) 
    : BaseInfrastructureDataDtoValidator<CommuteDto>(infrastructureDataRepository) 
{
}
