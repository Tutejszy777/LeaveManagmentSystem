﻿using LeaveManagementSystem.Application.Models.LeaveRequestDIR;
using LeaveManagementSystem.Application.Services.LeaveRequestDIR;
using LeaveManagementSystem.Application.Services.LeaveTypesDIR;
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
    public async Task<IActionResult> Create(int? leaveTypeId)
    {
        var leaveTypes = await _leaveTypeServices.GetAllLeaveTypesAsync();
        var leaveTypesList = new SelectList(leaveTypes, "Id", "Name", leaveTypeId);
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
    public async Task<IActionResult> Create(LeaveRequestCreateVM model)
    {
        if (await _leaveRequestService.RequestDatesExceedAllocation(model))
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
        await _leaveRequestService.CanceLeaveRequest(id);
        return RedirectToAction(nameof(Index));
    }

    // admin/supervisor review requests
    [Authorize(Policy = "AdminSupervisorOnly")]
    public async Task<IActionResult> ListRequests()
    {
        var model = await _leaveRequestService.GetAllLeaveRequests();
        return View(model);
    }

    // admin/supervisor review requests
    [Authorize(Policy = "AdminSupervisorOnly")]
    public async Task<IActionResult> Review(int id)
    {
        var model = await _leaveRequestService.GetLeaveRequestForReview(id);
        return View(model);
    }

    // admin/supervisor review requests
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = "AdminSupervisorOnly")]
    public async Task<IActionResult> Review(int id, bool approved)
    {
        await _leaveRequestService.ReviewLeaveRequest(id, approved);
        return RedirectToAction(nameof(Index));
    }
}
