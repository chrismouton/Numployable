namespace Numployable.Application.DTOs.ReferenceData.Validators;

using Persistence.Contracts;

public class SourceDtoValidator(IReferenceDataRepository<SourceDto> referenceDataRepository) 
    : BaseReferenceDataDtoValidator<SourceDto>(referenceDataRepository) 
{
}
