﻿
using Microsoft.EntityFrameworkCore;
using LeaveManagmentSystem.Web.Data;
using LeaveManagmentSystem.Web.Models.LeaveAllocationsDIR;
using AutoMapper;
using LeaveManagmentSystem.Web.Common;
using Microsoft.IdentityModel.Tokens;

namespace LeaveManagmentSystem.Web.Services.LeaveAllocationsDir;

public class LeaveAllocationService(ApplicationDbContext _context, IHttpContextAccessor _httpContextAccessor, UserManager<AppicationUser> _userManager, IMapper _mapper) : ILeaveAllocationService
{
    public async Task AllocateLeave(string EmployeeId)
    {
        //get all leaveTypes
        var leaveTypes = await _context.LeaveTypes.ToListAsync();

        // get current period based on year
        var currentDate = DateTime.Now;
        var period = await _context.Periods.SingleAsync(q => q.EndDate.Year == currentDate.Year);
        var monthsRemaining = period.EndDate.Month - currentDate.Month;


        // for each leave type create, create an allocation entry
        foreach (var item in leaveTypes)
        {
            var accuralRate = decimal.Divide(item.DefaultDays, 12);
            var leaveAllocation = new LeaveAllocation
            {
                EmployeeId = EmployeeId,
                LeaveTypeId = item.Id,
                PeriodId = period.Id,
                Days = (int) Math.Ceiling(accuralRate * monthsRemaining)
            };

            _context.Add(leaveAllocation);
        }

        await _context.SaveChangesAsync();

    }


    public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId)
    {
        var user = string.IsNullOrEmpty(userId) ? await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User) : await _userManager.FindByIdAsync(userId);

        var allocations = await GetAllocation(user.Id);
        var allocationsVmList = _mapper.Map<List<LeaveAllocation>, List<LeaveAllocationVM>>(allocations);

        var employeeVM = new EmployeeAllocationVM
        {
            DateOfBirth = user.DateOfBirth,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Id = user.Id,
            LeaveAllocations = allocationsVmList
        };

        return employeeVM;
    }

    public async Task<List<EmployeeListVM>> GetEmployees()
    {
        var users = await _userManager.GetUsersInRoleAsync(Roles.Employee);
        var employees = _mapper.Map <List<AppicationUser>,List<EmployeeListVM>>(users.ToList());

        return employees;
    }


    private async Task<List<LeaveAllocation>> GetAllocation(string? userId)
    {
        var currentDate = DateTime.Now;

        var leaveAllocations = await _context.LeaveAllocations
            .Include(q => q.LeaveType)
            .Include(q => q.Employee)
            .Where(q => q.EmployeeId == userId && q.Period.EndDate.Year == currentDate.Year)
            .ToListAsync();

        return leaveAllocations;
    }

}
