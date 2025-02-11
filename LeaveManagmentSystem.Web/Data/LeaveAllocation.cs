namespace LeaveManagmentSystem.Web.Data
{
    public class LeaveAllocation : BaseEntity
    {

        public LeaveType? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }

        public AppicationUser Employee { get; set; }
        public string EmployeeId { get; set; }

        public Period Period { get; set; }
        public int PeriodId { get; set; }

        public int Days { get; set; }
    }
}
