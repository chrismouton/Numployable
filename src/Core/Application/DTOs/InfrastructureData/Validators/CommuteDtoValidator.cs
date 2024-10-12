namespace Numployable.Application.DTOs.InfrastructureData.Validators;

using Persistence.Contracts;

public class CommuteDtoValidator(IInfrastructureDataRepository<CommuteDto> infrastructureDataRepository) 
    : BaseInfrastructureDataDtoValidator<CommuteDto>(infrastructureDataRepository) 
{
}
