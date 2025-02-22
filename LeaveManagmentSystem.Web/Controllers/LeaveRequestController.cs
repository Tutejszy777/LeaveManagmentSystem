namespace LeaveManagmentSystem.Web.Controllers;

[Authorize]
public class LeaveRequestController : Controller
{
    // Employee view requests
    public async Task<IActionResult> Index()
    {
        return View();
    }

    // Employee create requests
    public async Task<IActionResult> Create()
    {
        return View();
    }

    // Employee create requests
    [HttpPost]
    public async Task<IActionResult> Create(int create )
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
