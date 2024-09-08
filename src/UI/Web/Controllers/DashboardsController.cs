namespace Numployable.UI.Web.Controllers;

using Microsoft.AspNetCore.Mvc;
using Numployable.UI.Web.Contracts;

public class DashboardsController(IJobApplicationService jobApplicationService)
    : Controller
{
  public async Task<IActionResult> Index()
  {
    var model = await jobApplicationService.GetAll();

    return View(model);
  }
}
