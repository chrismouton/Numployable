namespace Numployable.Application.DTOs.ReferenceData.Validators;

using Persistence.Contracts;

public class CommuteDtoValidator(IReferenceDataRepository<CommuteDto> referenceDataRepository) 
    : BaseReferenceDataDtoValidator<CommuteDto>(referenceDataRepository) 
{
}
