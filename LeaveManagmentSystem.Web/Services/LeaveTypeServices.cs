﻿using AutoMapper;
using LeaveManagmentSystem.Web.Data;
using LeaveManagmentSystem.Web.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagmentSystem.Web.Services;

public class LeaveTypeServices : ILeaveTypeServices
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public LeaveTypeServices(ApplicationDbContext context, IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }

    public async Task<List<IndexReadOnlyVM>> GetAllLeaveTypesAsync()
    {
        //select * from leavetypes
        var data = await _context.LeaveTypes.ToListAsync();
        //convert data model to view model via automapper
        var viewData = _mapper.Map<List<IndexReadOnlyVM>>(data);
        return viewData;
    }

    public async Task<T?> Get<T>(int id) where T : class
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);

        if (data == null)
        {
            return null;
        }

        var viewData = _mapper.Map<T>(data);
        return viewData;
    }
    public async Task Remove(int id)
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(x => x.Id == id);
        if (data != null)
        {
            _context.LeaveTypes.Remove(data);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Edit(LeaveTypeEditVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Update(leaveType);
        await _context.SaveChangesAsync();
    }

    public async Task Create(LeaveTypeCreateVM model)
    {
        var data = _mapper.Map<LeaveType>(model);
        _context.LeaveTypes.Add(data);
        await _context.SaveChangesAsync();
    }

    public bool LeaveTypeExists(int id)
    {
        return _context.LeaveTypes.Any(e => e.Id == id);
    }

    public async Task<bool> CheckIfLeaveNameExists(string name)
    {
        var loverCaseName = name.ToLower();
        return await _context.LeaveTypes.AnyAsync(q => q.Name.ToLower().Equals(loverCaseName));
    }

    public async Task<bool> CheckIfLeaveNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit)
    {
        var loverCaseName = leaveTypeEdit.Name.ToLower();
        return await _context.LeaveTypes.AnyAsync(q => q.Name.ToLower().Equals(loverCaseName)
        && q.Id != leaveTypeEdit.Id);
    }
}
