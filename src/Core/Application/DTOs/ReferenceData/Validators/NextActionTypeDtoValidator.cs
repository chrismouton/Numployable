using Numployable.Application.Persistence.Contracts;

namespace Numployable.Application.DTOs.ReferenceData.Validators;

public class NextActionTypeDtoValidator(IReferenceDataRepository<NextActionTypeDto> referenceDataRepository)
    : BaseReferenceDataDtoValidator<NextActionTypeDto>(referenceDataRepository)
{
}