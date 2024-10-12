namespace Numployable.Application.DTOs.InfrastructureData.Validators;

using Persistence.Contracts;

public class ProcessStatusDtoValidator(IInfrastructureDataRepository<ProcessStatusDto> infrastructureDataRepository) 
    : BaseInfrastructureDataDtoValidator<ProcessStatusDto>(infrastructureDataRepository) 
{
}
