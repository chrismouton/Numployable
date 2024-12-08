using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Numployable.APIClient;
using Numployable.UI.Web.Contracts;
using Numployable.UI.Web.Models;

namespace Numployable.UI.Web.Controllers;

public class JobApplicationController(
  IJobApplicationService jobApplicationService,
  IRoleTypeService roleTypesService,
  IStatusService applicationStatusService,
  IProcessStatusService applicationProcessStatusService,
  ICommuteService commuteService) : Controller
{
  public async Task<IActionResult> Index()
  {
    List<JobApplicationViewModel>? model = await jobApplicationService.GetAll();

    return View(model);
  }

  // GET: JobApplication/Create
  public async Task<IActionResult> Create()
  {
    List<ReferenceDataViewModel> roleTypes = await roleTypesService.GetAll();
    SelectList? roleTypeItems = new(roleTypes, "Id", "Description");
    List<ReferenceDataViewModel> applicationStatuses = await applicationStatusService.GetAll();
    SelectList? applicationStatusList = new(applicationStatuses, "Id", "Description");
    List<ReferenceDataViewModel> applicationProcessStatuses = await applicationProcessStatusService.GetAll();
    SelectList? applicationProcessStatusList = new(applicationProcessStatuses, "Id", "Description");
    List<ReferenceDataViewModel> commute = await commuteService.GetAll();
    SelectList? commuteList = new(commute, "Id", "Description");

    CreateJobApplicationViewModel? model = new()
    {
      RoleTypeList = roleTypeItems,
      RoleName = string.Empty,
      CompanyName = string.Empty,
      ApplicationDate = DateTime.Now,
      StatusList = applicationStatusList,
      ProcessStatusList = applicationProcessStatusList,
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
      Response<int>? response = await jobApplicationService.Create(jobApplication);
      if (response.Success) return RedirectToAction(nameof(Index));
      ModelState.AddModelError("", response.ValidationErrors);
    }

    return View(jobApplication);
  }
}
