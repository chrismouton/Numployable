using Numployable.Application.Persistence.Contracts;

namespace Numployable.Application.DTOs.InfrastructureData.Validators;

public class NextActionTypeDtoValidator(IInfrastructureDataRepository<NextActionTypeDto> infrastructureDataRepository) 
    : BaseInfrastructureDataDtoValidator<NextActionTypeDto>(infrastructureDataRepository) 
{
}
