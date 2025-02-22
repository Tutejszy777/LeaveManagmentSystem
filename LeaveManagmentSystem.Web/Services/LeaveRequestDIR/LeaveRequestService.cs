using LeaveManagmentSystem.Web.Models.LeaveRequestDIR;

namespace LeaveManagmentSystem.Web.Services.LeaveRequestDIR
{
    public class LeaveRequestService : ILeaveRequestService
    {
        public Task CanceLeaveRequest(int leaveRequestId)
        {
            throw new NotImplementedException();
        }

        public Task CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveRequestListVM> GetAllLeaveRequests()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeLeaveRequestListVM> GetEmployeeLeaveRequest()
        {
            throw new NotImplementedException();
        }

        public Task ReviewLeaveRequest(ReviewLeaveRequestVM model)
        {
            throw new NotImplementedException();
        }
    }
}
