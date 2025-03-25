namespace LeaveManagementSystem.Application.Models.LeaveTypesDIR
{
    public class LeaveTypeDeleteVM : BaseLeaveTypeVM
    {
        public string Name { get; set; }

        [Display(Name = "Days left")]
        public int DefaultDays { get; set; }
    }
}
