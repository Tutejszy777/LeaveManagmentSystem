using LeaveManagmentSystem.Web.Common;
using LeaveManagmentSystem.Web.Services.LeaveAllocationsDir;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagmentSystem.Web.Controllers;

[Authorize]
public class LeaveAllocationController(ILeaveAllocationService _leaveAllocationService) : Controller
{
    [Authorize(Roles = Roles.Administrator)]
    public async Task<IActionResult> Index()
    {
        var employeeVM = await _leaveAllocationService.GetEmployees();
        return View(employeeVM);
    }

    [Authorize(Roles = Roles.Administrator)]
    public async Task<IActionResult> AllocateLeave(string userId)
    {
        await _leaveAllocationService.AllocateLeave(userId);
        return RedirectToAction(nameof(Details), new {userId}); // bind to Details userId
    }

    public async Task<IActionResult> Details(string? userId)
    {
        var employeeVM = await _leaveAllocationService.GetEmployeeAllocations(userId);
        return View(employeeVM);
    }
}
