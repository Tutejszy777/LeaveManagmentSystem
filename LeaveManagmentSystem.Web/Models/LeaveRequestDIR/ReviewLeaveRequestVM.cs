using LeaveManagmentSystem.Web.Models.LeaveAllocationsDIR;

namespace LeaveManagmentSystem.Web.Models.LeaveRequestDIR
{
    public class ReviewLeaveRequestVM : LeaveRequestReadOnlyVM
    {
        public EmployeeListVM Employee { get; set; } = new EmployeeListVM();
        public string? RequestComments { get; set; }
    }
}