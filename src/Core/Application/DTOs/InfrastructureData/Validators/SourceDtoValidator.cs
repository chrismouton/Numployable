using Numployable.Application.Persistence.Contracts;

namespace Numployable.Application.DTOs.InfrastructureData.Validators;

public class SourceDtoValidator(IInfrastructureDataRepository<SourceDto> infrastructureDataRepository) 
    : BaseInfrastructureDataDtoValidator<SourceDto>(infrastructureDataRepository) 
{
}
