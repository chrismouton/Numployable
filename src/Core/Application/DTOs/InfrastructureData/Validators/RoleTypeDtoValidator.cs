namespace Numployable.Application.DTOs.InfrastructureData.Validators;

using Persistence.Contracts;

public class RoleTypeDtoValidator(IInfrastructureDataRepository<RoleTypeDto> infrastructureDataRepository) 
    : BaseInfrastructureDataDtoValidator<RoleTypeDto>(infrastructureDataRepository) 
{
}
