using Numployable.Application.Persistence.Contracts;

namespace Numployable.Application.DTOs.ReferenceData.Validators;

public class SourceDtoValidator(IReferenceDataRepository<SourceDto> referenceDataRepository)
    : BaseReferenceDataDtoValidator<SourceDto>(referenceDataRepository)
{
}