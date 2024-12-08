using Numployable.Application.Persistence.Contracts;

namespace Numployable.Application.DTOs.ReferenceData.Validators;

public class ProcessStatusDtoValidator(IReferenceDataRepository<ProcessStatusDto> referenceDataRepository)
    : BaseReferenceDataDtoValidator<ProcessStatusDto>(referenceDataRepository)
{
}