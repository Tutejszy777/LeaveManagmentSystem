using LeaveManagementSystem.Application.Services.LeaveRequestDIR;
using System.ComponentModel;

namespace LeaveManagementSystem.Application.Models.LeaveRequestDIR
{
    public class LeaveRequestReadOnlyVM
    {
        public int Id { get; set; }

        [DisplayName("Start Date")]
        public DateOnly DateOnly { get; set; }

        [DisplayName("End Date")]
        public DateOnly DateEnd { get; set; }

        [DisplayName("Total days")]
        public int Days { get; set; }

        [DisplayName("Leave type")]
        public string LeaveType { get; set; } = string.Empty;

        [DisplayName("Status")]
        public LeaveRequestStatusEnum LeaveRequestsStatus { get; set; }
    }
}