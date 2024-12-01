using Numployable.UI.Web.Models;

namespace Numployable.UI.Web.Contracts;

public interface IInfrastractureDataService
{
  Task<List<InfrastructureDataViewModel>> GetAll();
}
