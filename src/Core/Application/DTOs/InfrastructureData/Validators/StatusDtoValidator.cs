namespace Numployable.Application.DTOs.InfrastructureData.Validators;

using Persistence.Contracts;

public class StatusDtoValidator(IInfrastructureDataRepository<StatusDto> infrastructureDataRepository) 
    : BaseInfrastructureDataDtoValidator<StatusDto>(infrastructureDataRepository) 
{
}
