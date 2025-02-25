using LeaveManagmentSystem.Web.Models.LeaveRequestDIR;

namespace LeaveManagmentSystem.Web.Services.LeaveRequestDIR
{
    public interface ILeaveRequestService
    {
        Task CreateLeaveRequest(LeaveRequestCreateVM model);
        Task<List<LeaveRequestReadOnlyVM>> GetEmployeeLeaveRequest();
        Task<LeaveRequestReadOnlyVM> GetAllLeaveRequests();
        Task CanceLeaveRequest(int leaveRequestId);
        Task ReviewLeaveRequest(ReviewLeaveRequestVM model );
        Task<bool> RequestDatesExceedAllocation(LeaveRequestCreateVM model);
    }
}