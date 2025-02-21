﻿namespace LeaveManagmentSystem.Web.Data
{
    public class LeaveRequest
    {
        public DateOnly DateOnly { get; set; }

        public DateOnly DateEnd { get; set; }


        public LeaveType? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }


        public LeaveRequestStatus? LeaveStatus { get; set; }
        public int LeaveStatusId { get; set; }


        public AppicationUser? Employee { get; set; }
        public string EmployeeId { get; set; }


        public AppicationUser? Reviewer { get; set; }
        public string? ReviewerId { get; set; }

        
        public string? RequestComments { get; set; }
    }
}