using LeaveManagmentSystem.Web.Common;
using LeaveManagmentSystem.Web.Models.LeaveAllocationsDIR;
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
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AllocateLeave(string userId)
    {
        await _leaveAllocationService.AllocateLeave(userId);
        return RedirectToAction(nameof(Details), new {userId}); // bind to Details userId
    }

    [Authorize(Roles = Roles.Administrator)]
    public async Task<IActionResult> EditAllocation(int? id)
    {
        if(id == null)
        {
            return NotFound();
        }

        var allocation = await _leaveAllocationService.GetEmployeeAllocation(id.Value);
        if(allocation == null)
        {
            return NotFound();
        }

        return View(allocation);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditAllocation(LeaveAllocationEditVM allocationEditVm)
    {
            await _leaveAllocationService.UpdateAllocation(allocationEditVm);
            return RedirectToAction(nameof(Details), new { userId = allocationEditVm.Employee.Id });
    }

    public async Task<IActionResult> Details(string? userId)
    {
        var employeeVM = await _leaveAllocationService.GetEmployeeAllocations(userId);
        return View(employeeVM);
    }
}
