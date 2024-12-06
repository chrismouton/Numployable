namespace Numployable.Application.DTOs.ReferenceData.Validators;

using Persistence.Contracts;

public class NextActionTypeDtoValidator(IReferenceDataRepository<NextActionTypeDto> referenceDataRepository) 
    : BaseReferenceDataDtoValidator<NextActionTypeDto>(referenceDataRepository) 
{
}
