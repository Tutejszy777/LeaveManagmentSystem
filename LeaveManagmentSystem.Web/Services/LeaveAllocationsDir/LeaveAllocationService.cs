
using Microsoft.EntityFrameworkCore;
using LeaveManagmentSystem.Web.Data;
using LeaveManagmentSystem.Web.Models.LeaveAllocationsDIR;
using AutoMapper;
using LeaveManagmentSystem.Web.Common;
using Microsoft.IdentityModel.Tokens;
using LeaveManagmentSystem.Web.Services.PeriodDIR;
using LeaveManagmentSystem.Web.Services.Users;

namespace LeaveManagmentSystem.Web.Services.LeaveAllocationsDir;

public class LeaveAllocationService(ApplicationDbContext _context, IUserService _userService, IMapper _mapper, IPeriodService _periodService) : ILeaveAllocationService
{
    public async Task AllocateLeave(string employeeId)
    {
        //get all leaveTypes
        var leaveTypes = await _context.LeaveTypes
            .Where(q => !q.LeaveAllocations.Any(x => x.EmployeeId == employeeId))
            .ToListAsync();

        // get current period based on year
        var period = await _periodService.GetCurrentPeriod();
        var monthsRemaining = period.EndDate.Month - DateTime.Now.Month;


        // for each leave type create, create an allocation entry
        foreach (var item in leaveTypes)
        {
            // works, but not best practice
            //var allocationExists = await AllocationExists(employeeId, period.Id, item.Id);
            //if(allocationExists) continue;

            var accuralRate = decimal.Divide(item.DefaultDays, 12);
            var leaveAllocation = new LeaveAllocation
            {
                EmployeeId = employeeId,
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
        var user = string.IsNullOrEmpty(userId)
            ? await _userService.GetLoggedInUser()
            : await _userService.GetUserById(userId);

        var allocations = await GetAllocation(user.Id);
        var allocationsVmList = _mapper.Map<List<LeaveAllocation>, List<LeaveAllocationVM>>(allocations);
        var leaveTypesCount = await _context.LeaveTypes.CountAsync();

        var employeeVM = new EmployeeAllocationVM
        {
            DateOfBirth = user.DateOfBirth,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Id = user.Id,
            LeaveAllocations = allocationsVmList,
            IsCompletedAllocation = leaveTypesCount == allocations.Count()
        };

        return employeeVM;
    }

    public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int allocationId)
    {
        var allocation = await _context.LeaveAllocations
            .Include(q => q.LeaveType)
            .Include(q => q.Employee)
            .FirstOrDefaultAsync(q => q.Id == allocationId);

        var model = _mapper.Map<LeaveAllocation, LeaveAllocationEditVM>(allocation);

        return model;
    }

    public async Task<List<EmployeeListVM>> GetEmployees()
    {
        var users = await _userService.GetEmployees();
        var employees = _mapper.Map <List<AppicationUser>,List<EmployeeListVM>>(users.ToList());

        return employees;
    }

    public async Task UpdateAllocation(LeaveAllocationEditVM allocationEditVM)
    {
        //var leaveAllocation = await GetEmployeeAllocation(allocationEditVM.Id)
        //    ?? throw new Exception("Leave allocation record does not exist."); // checks if null

        //leaveAllocation.Days = allocationEditVM.Days;
        // option 1 (less efficient)  _context.Update(leaveAllocation);
        // option 2  _context.Entry(leaveAllocation).State = EntityState.Modified;
        // await _context.SaveChangesAsync();

        await _context.LeaveAllocations
            .Where(q => q.Id == allocationEditVM.Id)
            .ExecuteUpdateAsync(s => s.SetProperty(e => e.Days, allocationEditVM.Days));
    }

    public async Task<LeaveAllocation> GetCurrentAllocation(string userId, int leaveTypeId)
    {
        var period = await _periodService.GetCurrentPeriod();
        var allocation = await _context.LeaveAllocations
            .FirstOrDefaultAsync(q => q.EmployeeId == userId 
                && q.LeaveTypeId == leaveTypeId 
                && q.PeriodId == period.Id);

        return allocation;
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

    private async Task<bool> AllocationExists(string userId, int periodId, int LeaveTypeId)
    {
        var exists = await _context.LeaveAllocations.AnyAsync(q =>
            q.EmployeeId == userId 
            && q.PeriodId == periodId 
            && q.LeaveTypeId == LeaveTypeId);

        return exists;
    }

}
