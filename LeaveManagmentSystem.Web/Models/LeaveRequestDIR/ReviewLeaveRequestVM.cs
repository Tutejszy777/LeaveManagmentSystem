using LeaveManagmentSystem.Web.Models.LeaveAllocationsDIR;
using System.ComponentModel;

namespace LeaveManagmentSystem.Web.Models.LeaveRequestDIR
{
    public class ReviewLeaveRequestVM : LeaveRequestReadOnlyVM
    {
        public EmployeeListVM Employee { get; set; } = new EmployeeListVM();
        [DisplayName("Additional info")]
        public string? RequestComments { get; set; }
    }
}