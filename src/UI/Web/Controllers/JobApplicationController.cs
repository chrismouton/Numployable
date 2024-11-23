using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Numployable.UI.Web.Contracts;
using Numployable.UI.Web.Models;

namespace Numployable.UI.Web.Controllers;

public class JobApplicationController(IJobApplicationService jobApplicationService,
                                      IRoleTypeService roleTypesService,
                                      IApplicationStatusService applicationStatusService,
                                      IApplicationProcessStatusService applicationProcessStatusService,
                                      ICommuteService commuteService) : Controller
{
  public async Task<IActionResult> Index()
  {
    var model = await jobApplicationService.GetAll();

    return View(model);
  }

  // GET: JobApplication/Create
  public async Task<IActionResult> Create()
  {
    List<InfrastructureDataViewModel> roleTypes = await roleTypesService.GetAll();
    var roleTypeItems = new SelectList(roleTypes, "Id", "Description");
    List<InfrastructureDataViewModel> applicationStatuses = await applicationStatusService.GetAll();
    var applicationStatusList = new SelectList(applicationStatuses, "Id", "Description");
    List<InfrastructureDataViewModel> applicationProcessStatuses = await applicationProcessStatusService.GetAll();
    var applicationProcessStatusList = new SelectList(applicationProcessStatuses, "Id", "Description");
    List<InfrastructureDataViewModel> commute = await commuteService.GetAll();
    var commuteList = new SelectList(commute, "Id", "Description");

    var model = new CreateJobApplicationViewModel
    {
      RoleTypeList = roleTypeItems,
      RoleName = string.Empty,
      CompanyName = string.Empty,
      ApplicationDate = DateTime.Now,
      ApplicationStatusList = applicationStatusList,
      ApplicationProcessStatusList = applicationProcessStatusList,
      CommuteList = commuteList
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
