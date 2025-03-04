using LeaveManagementSystem.Application.Models.LeaveAllocationsDIR;
using LeaveManagementSystem.Application.Services.LeaveAllocationsDir;
using LeaveManagementSystem.Application.Services.LeaveTypesDIR;

namespace LeaveManagmentSystem.Web.Controllers;

[Authorize]
public class LeaveAllocationController(ILeaveAllocationService _leaveAllocationService, ILeaveTypeServices _leaveTypeServices) : Controller
{
    [Authorize(Roles = Roles.Administrator)]
    public async Task<IActionResult> Index()
    {
        var employeeVM = await _leaveAllocationService.GetEmployees();
        return View(employeeVM);
    }

    [Authorize(Roles = Roles.Administrator)]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AllocateLeave(string userId)
    {
        await _leaveAllocationService.AllocateLeave(userId);
        return RedirectToAction(nameof(Details), new { userId }); // bind to Details userId
    }

    [Authorize(Roles = Roles.Administrator)]
    public async Task<IActionResult> EditAllocation(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var allocation = await _leaveAllocationService.GetEmployeeAllocation(id.Value);
        if (allocation == null)
        {
            return NotFound();
        }

        return View(allocation);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditAllocation(LeaveAllocationEditVM allocationEditVm)
    {
        if (await _leaveTypeServices.DaysExceedMaximum(allocationEditVm.LeaveType.Id, allocationEditVm.Days))
        {
            ModelState.AddModelError("Days", "You have exceeded the maximum days for this leave type");
        }
        if (ModelState.IsValid)
        {
            await _leaveAllocationService.UpdateAllocation(allocationEditVm);
            return RedirectToAction(nameof(Details), new { userId = allocationEditVm.Employee.Id });
        }
        var days = allocationEditVm.Days;

        allocationEditVm = await _leaveAllocationService.GetEmployeeAllocation(allocationEditVm.Id);
        allocationEditVm.Days = days;
        return View(allocationEditVm);
    }

    public async Task<IActionResult> Details(string? userId)
    {
        var employeeVM = await _leaveAllocationService.GetEmployeeAllocations(userId);
        return View(employeeVM);
    }
}
