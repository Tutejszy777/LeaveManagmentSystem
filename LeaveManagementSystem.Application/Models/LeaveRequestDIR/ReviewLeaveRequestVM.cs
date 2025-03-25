using System.ComponentModel;

namespace LeaveManagementSystem.Application.Models.LeaveRequestDIR
{
    public class ReviewLeaveRequestVM : LeaveRequestReadOnlyVM
    {
        public EmployeeListVM Employee { get; set; } = new EmployeeListVM();
        [DisplayName("Additional info")]
        public string? RequestComments { get; set; }
    }
}