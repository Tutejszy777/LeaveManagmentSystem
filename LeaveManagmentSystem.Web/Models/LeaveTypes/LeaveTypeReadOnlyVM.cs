using System.ComponentModel.DataAnnotations;

namespace LeaveManagmentSystem.Web.Models.LeaveTypes
{
    public class LeaveTypeReadOnlyVM : BaseLeaveTypeVM
    {
        public string Name { get; set; }

        [Display(Name = "Days left")]
        public int DefaultDays { get; set; }
    }
}
