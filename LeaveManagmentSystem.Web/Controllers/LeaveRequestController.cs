using LeaveManagmentSystem.Web.Models.LeaveRequestDIR;
using LeaveManagmentSystem.Web.Services.LeaveRequestDIR;
using LeaveManagmentSystem.Web.Services.LeaveTypes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeaveManagmentSystem.Web.Controllers;

[Authorize]
public class LeaveRequestController(ILeaveTypeServices _leaveTypeServices, ILeaveRequestService _leaveRequestService) : Controller
{
    // Employee view requests
    public async Task<IActionResult> Index()
    {
        var model = await _leaveRequestService.GetEmployeeLeaveRequest();
        return View(model);
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
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(LeaveRequestCreateVM model )
    {
        if(await _leaveRequestService.RequestDatesExceedAllocation(model))
        {
            ModelState.AddModelError("", "You have exceeded your allocations.");
            ModelState.AddModelError(nameof(model.DateEnd), "The number of days request is invalid.");
        }

        if (ModelState.IsValid)
        {
            await _leaveRequestService.CreateLeaveRequest(model);
            return RedirectToAction(nameof(Index));
        }
        var leaveTypes = await _leaveTypeServices.GetAllLeaveTypesAsync();
        model.LeaveTypeList = new SelectList(leaveTypes, "Id", "Name");
        return View(model);
    }

    // Employee Cancel requests
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cancel(int id)
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
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Review()
    {
        return View();
    }
}
