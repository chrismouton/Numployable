namespace Numployable.Application.DTOs.ReferenceData.Validators;

using Persistence.Contracts;

public class RoleTypeDtoValidator(IReferenceDataRepository<RoleTypeDto> referenceDataRepository) 
    : BaseReferenceDataDtoValidator<RoleTypeDto>(referenceDataRepository) 
{
}
