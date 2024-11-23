using Numployable.Application.Persistence.Contracts;

namespace Numployable.Application.DTOs.InfrastructureData.Validators;

public class ProcessStatusDtoValidator(IInfrastructureDataRepository<ProcessStatusDto> infrastructureDataRepository) 
    : BaseInfrastructureDataDtoValidator<ProcessStatusDto>(infrastructureDataRepository) 
{
}
