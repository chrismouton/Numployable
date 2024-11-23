using Numployable.Application.Persistence.Contracts;

namespace Numployable.Application.DTOs.InfrastructureData.Validators;

public class RoleTypeDtoValidator(IInfrastructureDataRepository<RoleTypeDto> infrastructureDataRepository) 
    : BaseInfrastructureDataDtoValidator<RoleTypeDto>(infrastructureDataRepository) 
{
}
