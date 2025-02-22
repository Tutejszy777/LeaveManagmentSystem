namespace LeaveManagmentSystem.Web.Models.LeaveRequestDIR
{
    public class LeaveRequestCreateVM
    {
        public DateOnly DateOnly { get; set; }
        public DateOnly DateEnd { get; set; }
        public int LeaveTypeId { get; set; }
        public string? RequestComments { get; set; }
    }
}