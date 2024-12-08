using Numployable.Application.Persistence.Contracts;

namespace Numployable.Application.DTOs.ReferenceData.Validators;

public class StatusDtoValidator(IReferenceDataRepository<StatusDto> referenceDataRepository)
    : BaseReferenceDataDtoValidator<StatusDto>(referenceDataRepository)
{
}