namespace Numployable.UI.Web.Contracts;

using Numployable.APIClient;
using Numployable.UI.Web.Models;

public interface INextActionService
{
    Task<List<NextActionViewModel>> GetNextActions();

    Task<NextActionViewModel> GetNextActionDetails(int id);

    Task<Response<int>> CreateNextAction(NextActionViewModel nextAction);

    Task<Response<int>> UpdateNextAction(int id, NextActionViewModel nextAction);
}
