using LeaveManagmentSystem.Web.Models.LeaveAllocationsDIR;

namespace LeaveManagmentSystem.Web.Services.LeaveAllocationsDir;

public interface ILeaveAllocationService
{
    Task AllocateLeave(string EmployeeId);
    Task<List<LeaveAllocation>> GetAllocation();
    Task<EmployeeAllocationVM> GetEmployeeAllocations();
}
