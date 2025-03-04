namespace LeaveManagementSystem.Application.Services.LeaveAllocationsDir;

public interface ILeaveAllocationService
{
    Task AllocateLeave(string employeeId);
    Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId);
    Task<LeaveAllocationEditVM> GetEmployeeAllocation(int allocationId);
    Task<List<EmployeeListVM>> GetEmployees();
    Task UpdateAllocation(LeaveAllocationEditVM allocationEditVM);
    Task<LeaveAllocation> GetCurrentAllocation(string userId, int leaveTypeId);
}
