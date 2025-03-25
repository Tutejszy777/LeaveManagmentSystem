namespace LeaveManagementSystem.Application.Services.LeaveRequestDIR
{
    public interface ILeaveRequestService
    {
        Task CreateLeaveRequest(LeaveRequestCreateVM model);
        Task<List<LeaveRequestReadOnlyVM>> GetEmployeeLeaveRequest();
        Task<EmployeeLeaveRequestListVM> GetAllLeaveRequests();
        Task CanceLeaveRequest(int leaveRequestId);
        Task ReviewLeaveRequest(int id, bool approved);
        Task<bool> RequestDatesExceedAllocation(LeaveRequestCreateVM model);
        Task<ReviewLeaveRequestVM> GetLeaveRequestForReview(int id);
    }
}