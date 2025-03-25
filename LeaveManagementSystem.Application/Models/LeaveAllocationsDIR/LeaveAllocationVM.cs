namespace LeaveManagementSystem.Application.Models.LeaveAllocationsDIR;

public class LeaveAllocationVM
{
    public int Id { get; set; }

    [Display(Name = " No. of days")]
    public int Days { get; set; }

    [Display(Name = "Allocation Period")]
    public PeriodVM Period { get; set; } = new PeriodVM();

    public LeaveTypeReadOnlyVM? LeaveType { get; set; } = new LeaveTypeReadOnlyVM();

}
