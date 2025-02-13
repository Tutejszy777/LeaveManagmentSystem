namespace LeaveManagmentSystem.Web.Services.LeaveAllocationsDir;

public interface ILeaveAllocationService
{
    Task AllocateLeave(string EmployeeId);
}
