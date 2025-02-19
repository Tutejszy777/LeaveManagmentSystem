﻿using LeaveManagmentSystem.Web.Models.LeaveAllocationsDIR;

namespace LeaveManagmentSystem.Web.Services.LeaveAllocationsDir;

public interface ILeaveAllocationService
{
    Task AllocateLeave(string employeeId);
    Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId); 
    Task<LeaveAllocationEditVM> GetEmployeeAllocation(int allocationId);
    Task<List<EmployeeListVM>> GetEmployees();
    Task UpdateAllocation(LeaveAllocationEditVM allocationEditVM);
}
