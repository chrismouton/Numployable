using Numployable.UI.Web.Models;

namespace Numployable.UI.Web.Contracts;

public interface IReferenceDataService
{
  Task<List<InfrastructureDataViewModel>> GetAll();
}
