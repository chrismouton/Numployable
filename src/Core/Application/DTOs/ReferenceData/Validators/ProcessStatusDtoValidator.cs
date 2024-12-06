namespace Numployable.Application.DTOs.ReferenceData.Validators;

using Persistence.Contracts;

public class ProcessStatusDtoValidator(IReferenceDataRepository<ProcessStatusDto> referenceDataRepository) 
    : BaseReferenceDataDtoValidator<ProcessStatusDto>(referenceDataRepository) 
{
}
