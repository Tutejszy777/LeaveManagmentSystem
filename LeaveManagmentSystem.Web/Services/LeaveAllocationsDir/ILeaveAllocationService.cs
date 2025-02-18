using LeaveManagmentSystem.Web.Models.LeaveAllocationsDIR;

namespace LeaveManagmentSystem.Web.Services.LeaveAllocationsDir;

public interface ILeaveAllocationService
{
    Task AllocateLeave(string employeeId);
    Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId);
    Task<List<EmployeeListVM>> GetEmployees();
}
