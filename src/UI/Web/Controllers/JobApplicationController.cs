namespace Numployable.UI.Web.Controllers;

using Microsoft.AspNetCore.Mvc;
using Numployable.UI.Web.Contracts;
using Numployable.UI.Web.Models;

public class JobApplicationController(IJobApplicationService jobApplicationService) : Controller
{
  IJobApplicationService jobApplicationService = jobApplicationService;

  public async Task<IActionResult> Index()
  {
    var model = await jobApplicationService.GetAll();

    return View(model);
  }

  // GET: JobApplication/Create
  public ActionResult Create()
  {
    var model = new CreateJobApplicationViewModel
    {
      RoleType = RoleType.Permanent,
      RoleName = string.Empty,
      CompanyName = string.Empty,
      ApplicationDate = DateTime.Now,
      ApplicationStatus = Status.Active,
    };

    return View(model);
  }

  // POST: JobApplication/Create
  [HttpPost]
  public async Task<ActionResult> Create(CreateJobApplicationViewModel jobApplication)
  {
    if (ModelState.IsValid)
    {
      var response = await jobApplicationService.Create(jobApplication);
      if (response.Success)
      {
        return RedirectToAction(nameof(Index));
      }
      ModelState.AddModelError("", response.ValidationErrors);
    }

    return View(jobApplication);
  }
}
