using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace LeaveManagmentSystem.Web.Models.LeaveRequestDIR
{
    public class LeaveRequestCreateVM
    {
        [DisplayName("Start Date")]
        public DateOnly DateOnly { get; set; }
        [DisplayName("End Date")]

        public DateOnly DateEnd { get; set; }
        [DisplayName("Leave type")]

        public int LeaveTypeId { get; set; }
        [DisplayName("Additional information")]

        public string? RequestComments { get; set; }

        public SelectList LeaveTypeList { get; set; }
    }
}