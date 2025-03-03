namespace LeaveManagmentSystem.Web.Models.LeaveRequestDIR
{
    public class EmployeeLeaveRequestListVM
    {
        [Display(Name = "Total number of requests")]
        public int TotalRequests { get; set; }

        [Display(Name = "Approved requests")]
        public int ApprovedRequests { get; set; }

        [Display(Name = "Pending requests")]
        public int PendingRequests { get; set; }

        [Display(Name = "Declined requests")]
        public int DeclinedRequests { get; set; }

        [Display(Name = "Pending requests")]
        public List<LeaveRequestReadOnlyVM> LeaveRequests { get; set; } = new List<LeaveRequestReadOnlyVM>();
    }
}