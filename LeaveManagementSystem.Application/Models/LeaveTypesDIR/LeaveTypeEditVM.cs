namespace LeaveManagementSystem.Application.Models.LeaveTypesDIR
{
    public class LeaveTypeEditVM : BaseLeaveTypeVM
    {

        [Required]
        [Length(4, 150, ErrorMessage = "You have length violated requirments")]
        public string Name { get; set; }
        [Required]
        [Range(1, 90, ErrorMessage = "You have range violated requirments")]
        [Display(Name = "Days left")]
        public int DefaultDays { get; set; }
    }
}
