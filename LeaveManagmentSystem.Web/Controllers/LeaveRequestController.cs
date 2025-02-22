using LeaveManagmentSystem.Web.Models.LeaveRequestDIR;
using LeaveManagmentSystem.Web.Services.LeaveTypes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeaveManagmentSystem.Web.Controllers;

[Authorize]
public class LeaveRequestController(ILeaveTypeServices _leaveTypeServices) : Controller
{
    // Employee view requests
    public async Task<IActionResult> Index()
    {
        return View();
    }

    // Employee create requests
    public async Task<IActionResult> Create()
    {
        var leaveTypes = await _leaveTypeServices.GetAllLeaveTypesAsync();
        var leaveTypesList = new SelectList(leaveTypes, "Id", "Name");
        var model = new LeaveRequestCreateVM
        {
            DateOnly = DateOnly.FromDateTime(DateTime.Now),
            DateEnd = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
            LeaveTypeList = leaveTypesList
        };
        return View(model);
    }

    // Employee create requests
    [HttpPost]
    public async Task<IActionResult> Create(LeaveRequestCreateVM model )
    {
        return View();
    }

    // Employee Cancel requests
    [HttpPost]
    public async Task<IActionResult> Cancel(int leaveRequestId)
    {
        return View();
    }

    // admin/supervisor review requests
    public async Task<IActionResult> ListRequests()
    {
        return View();
    }

    // admin/supervisor review requests
    public async Task<IActionResult> Review(int leaveRequestId)
    {
        return View();
    }

    // admin/supervisor review requests
    [HttpPost]
    public async Task<IActionResult> Review()
    {
        return View();
    }
}
