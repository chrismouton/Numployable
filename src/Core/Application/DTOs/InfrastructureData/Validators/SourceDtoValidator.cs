namespace Numployable.Application.DTOs.InfrastructureData.Validators;

using Persistence.Contracts;

public class SourceDtoValidator(IInfrastructureDataRepository<SourceDto> infrastructureDataRepository) 
    : BaseInfrastructureDataDtoValidator<SourceDto>(infrastructureDataRepository) 
{
}
