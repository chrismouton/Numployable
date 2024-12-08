using Numployable.Application.Persistence.Contracts;

namespace Numployable.Application.DTOs.ReferenceData.Validators;

public class CommuteDtoValidator(IReferenceDataRepository<CommuteDto> referenceDataRepository)
    : BaseReferenceDataDtoValidator<CommuteDto>(referenceDataRepository)
{
}