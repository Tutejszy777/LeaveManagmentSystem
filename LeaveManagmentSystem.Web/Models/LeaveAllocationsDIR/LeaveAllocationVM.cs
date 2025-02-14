using LeaveManagmentSystem.Web.Models.LeaveTypes;
using LeaveManagmentSystem.Web.Models.PeriodsDIR;

namespace LeaveManagmentSystem.Web.Models.LeaveAllocationsDIR
{
    public class LeaveAllocationVM
    {
        public int Id { get; set; }

        [Display(Name = " No. of days")]
        public int NumberOfDays { get; set; }

        [Display(Name = "Allocation Period")]
        public PeriodVM Period { get; set; } = new PeriodVM();

        public LeaveTypeReadOnlyVM? LeaveType { get; set; } = new LeaveTypeReadOnlyVM(); 

    }
}
