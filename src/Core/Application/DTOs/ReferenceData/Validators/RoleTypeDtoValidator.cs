using Numployable.Application.Persistence.Contracts;

namespace Numployable.Application.DTOs.ReferenceData.Validators;

public class RoleTypeDtoValidator(IReferenceDataRepository<RoleTypeDto> referenceDataRepository)
    : BaseReferenceDataDtoValidator<RoleTypeDto>(referenceDataRepository)
{
}