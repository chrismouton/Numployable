namespace Numployable.Application.DTOs.ReferenceData.Validators;

using Persistence.Contracts;

public class StatusDtoValidator(IReferenceDataRepository<StatusDto> referenceDataRepository) 
    : BaseReferenceDataDtoValidator<StatusDto>(referenceDataRepository) 
{
}
