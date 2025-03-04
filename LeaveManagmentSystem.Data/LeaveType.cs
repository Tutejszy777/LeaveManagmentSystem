using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagmentSystem.Data
{
    public class LeaveType : BaseEntity
    {
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        public int DefaultDays { get; set; }

        public List<LeaveAllocation>? LeaveAllocations { get; set; }
    }
}
