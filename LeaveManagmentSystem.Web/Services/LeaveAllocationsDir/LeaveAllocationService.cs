
using Microsoft.EntityFrameworkCore;
using LeaveManagmentSystem.Web.Data;

namespace LeaveManagmentSystem.Web.Services.LeaveAllocationsDir;

public class LeaveAllocationService(ApplicationDbContext _context) : ILeaveAllocationService
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
}
