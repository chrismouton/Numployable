namespace Numployable.Application.DTOs.InfrastructureData.Validators;

using Persistence.Contracts;

public class NextActionTypeDtoValidator(IInfrastructureDataRepository<NextActionTypeDto> infrastructureDataRepository) 
    : BaseInfrastructureDataDtoValidator<NextActionTypeDto>(infrastructureDataRepository) 
{
}
