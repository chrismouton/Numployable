using Numployable.Application.Persistence.Contracts;

namespace Numployable.Application.DTOs.InfrastructureData.Validators;

public class StatusDtoValidator(IInfrastructureDataRepository<StatusDto> infrastructureDataRepository) 
    : BaseInfrastructureDataDtoValidator<StatusDto>(infrastructureDataRepository) 
{
}
