using LeaveManagmentSystem.Web.Common;
using LeaveManagmentSystem.Web.Services.LeaveAllocationsDir;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagmentSystem.Web.Controllers;

[Authorize]
public class LeaveAllocationController(ILeaveAllocationService _leaveAllocationService) : Controller
{
    public async Task<IActionResult> Details()
    {
        var employeeVM = await _leaveAllocationService.GetEmployeeAllocations();
        return View(employeeVM);
    }
}
