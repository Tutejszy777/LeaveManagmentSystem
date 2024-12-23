﻿using System.ComponentModel.DataAnnotations;

namespace LeaveManagmentSystem.Web.Models.LeaveTypes
{
    public class IndexReadOnlyVM : BaseLeaveTypeVM
    {
        public string Name { get; set; }

        [Display(Name = "Days left")]
        public int DefaultDays { get; set; }
    }
}
