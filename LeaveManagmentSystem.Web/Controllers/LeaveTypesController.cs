using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagmentSystem.Web.Models.LeaveTypes;
using AutoMapper;
using LeaveManagmentSystem.Data.Migrations;
using LeaveManagmentSystem.Web.Services.LeaveTypes;

namespace LeaveManagmentSystem.Web.Controllers;

[Authorize(Roles = Roles.Administrator)]
public class LeaveTypesController(ILeaveTypeServices leaveTypeServices) : Controller
{
    private readonly ILeaveTypeServices _leaveTypeServices = leaveTypeServices;

    // GET: LeaveTypes
    public async Task<IActionResult> Index()
    {
        // SELECT * FROM LeaveTypes
        //var data = await _context.LeaveTypes.ToListAsync();

        //var viewData = _mapper.Map<List<IndexReadOnlyVM>>(data);

        // data model to viw model
        //var viewData = data.Select(p => new IndexVM
        //{
        //    Id = p.Id,
        //    Name = p.Name,
        //    NumberOfDays = p.DefaultDays.ToString(),
        //});

        var viewData = await _leaveTypeServices.GetAllLeaveTypesAsync();

        return View(viewData);
    }

    // GET: LeaveTypes/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var leaveType = await _leaveTypeServices.Get<LeaveTypeReadOnlyVM>(id.Value);

        if (leaveType == null)
        {
            return NotFound();
        }

        

        return View(leaveType);
    }

    // GET: LeaveTypes/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: LeaveTypes/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(LeaveTypeCreateVM leaveTypeCreate)
    {
        if (await _leaveTypeServices.CheckIfLeaveNameExists(leaveTypeCreate.Name))
        {
            ModelState.AddModelError(nameof(leaveTypeCreate.Name), "Name already exists in db");
        }

        if (ModelState.IsValid)
        {
            await _leaveTypeServices.Create(leaveTypeCreate);
            return RedirectToAction(nameof(Index));
        }
        return View(leaveTypeCreate);
    }

    // GET: LeaveTypes/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var leaveType = await _leaveTypeServices.Get<LeaveTypeEditVM>(id.Value);
        if (leaveType == null)
        {
            return NotFound();
        }

        return View(leaveType);
    }

    // POST: LeaveTypes/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, LeaveTypeEditVM leaveTypeEdit)
    {
        if (id != leaveTypeEdit.Id)
        {
            return NotFound();
        }

        if (await _leaveTypeServices.CheckIfLeaveNameExistsForEdit(leaveTypeEdit))
        {
            ModelState.AddModelError(nameof(leaveTypeEdit.Name), "Name already exists in db");
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _leaveTypeServices.Edit(leaveTypeEdit);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_leaveTypeServices.LeaveTypeExists(leaveTypeEdit.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(leaveTypeEdit);
    }

    // GET: LeaveTypes/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var leaveType = await _leaveTypeServices.Get<LeaveTypeDeleteVM>(id.Value);

        if (leaveType == null)
        {
            return NotFound();
        }

        return View(leaveType);
    }

    // POST: LeaveTypes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _leaveTypeServices.Remove(id);
        return RedirectToAction(nameof(Index));
    }

}
