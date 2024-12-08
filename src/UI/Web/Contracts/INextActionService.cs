using Numployable.APIClient;
using Numployable.UI.Web.Models;

namespace Numployable.UI.Web.Contracts;

public interface INextActionService
{
  Task<List<NextActionViewModel>> GetAll();

  Task<NextActionViewModel> Get(int id);

  Task<Response<int>> Create(CreateNextActionViewModel nextAction);

  Task<Response<int>> Update(int id, NextActionViewModel nextAction);
}
