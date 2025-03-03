using System.ComponentModel.DataAnnotations;

namespace LeaveManagmentSystem.Web.Models.LeaveTypes
{
    public class  LeaveTypeDeleteVM : BaseLeaveTypeVM
    {
        public string Name { get; set; }

        [Display(Name = "Days left")]
        public int DefaultDays { get; set; }
    }
}
