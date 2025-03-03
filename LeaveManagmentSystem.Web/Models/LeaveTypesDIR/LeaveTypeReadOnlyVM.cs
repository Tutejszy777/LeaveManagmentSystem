using System.ComponentModel.DataAnnotations;

namespace LeaveManagmentSystem.Web.Models.LeaveTypes
{
    public class LeaveTypeReadOnlyVM : BaseLeaveTypeVM
    {
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Days left")]
        public int DefaultDays { get; set; }
    }
}
