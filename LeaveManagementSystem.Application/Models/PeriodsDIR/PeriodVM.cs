﻿namespace LeaveManagementSystem.Application.Models.PeriodsDIR
{
    public class PeriodVM
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }
    }
}
