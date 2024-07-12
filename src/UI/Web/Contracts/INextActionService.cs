using Numployable.UI.Web.Models;
using Numployable.UI.Web.Services.Base;

namespace Numployable.UI.Web.Contracts;

public interface INextActionService
{
    Task<List<NextActionViewModel>> GetNextActions();

    Task<NextActionViewModel> GetNextActionDetails(int id);

    Task<Response<int>> CreateNextAction(NextActionViewModel nextAction);

    Task<Response<int>> UpdateNextAction(int id, NextActionViewModel nextAction);
}